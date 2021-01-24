    Camera.CameraInfo camInfo = new Camera.CameraInfo ();
    for (int i = 0; i < Camera.NumberOfCameras; i++) {
        Camera.GetCameraInfo (i, camInfo);
        if (camInfo.Facing == CameraFacing.Front){
            try {
                return Camera.Open(i);
            } catch (Exception e) {
                // log or something
            }
        }
    }
    return null;
