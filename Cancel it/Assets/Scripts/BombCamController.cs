using UnityEngine;
using Unity.Cinemachine;

public class BombCamController : MonoBehaviour
{
    [Header("6つのバーチャルカメラ（正面、背面、左側、右側、上側、下側）")]
    public CinemachineCamera[] cinemachineCameras;

    private int currentCameraIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwichCamera(0);
    }

    public void SwichCamera(int index)
    {
        if(cinemachineCameras == null || cinemachineCameras.Length == 0)
        {
            Debug.LogWarning("カメラが設定されていません。");
            return;
        }

        for(int i = 0; i < cinemachineCameras.Length; i++) // 6つのカメラの優先度を切り替える
        {
            if (cinemachineCameras[i] != null)
            {
                cinemachineCameras[i].Priority = (i == index) ? 10 : 0; // 選択されたカメラの優先度を10に設定し、他のカメラの優先度を0に設定
            }
        }
        currentCameraIndex = index;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) // キー1～6が押された場合
            {
                SwichCamera(i);
            }
        }
    }
}
