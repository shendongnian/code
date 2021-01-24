         CameraDevice.CameraDirection currentDir = CameraDevice.Instance.GetCameraDirection();
         if (!cameraMode)
         {
             RestartCamera(CameraDevice.CameraDirection.CAMERA_FRONT);
             cameramode = true;
             Debug.Log("Back Camera");
         }
         else
         {
             RestartCamera(CameraDevice.CameraDirection.CAMERA_BACK);
             cameramode = false;
             Debug.Log("Front Camera");
         }
     
