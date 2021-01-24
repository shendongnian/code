    public YourConstructor()
    {
        Capture = new VideoCapture();
    }
    private void CaptureCameraFrame()
    {
        CameraModel.Instance.CameraViewMat = Capture.QueryFrame();
        // do stuff with queried matrix here
        if(noAbortCondition)
        {
            CaptureCameraFrame();
        }
    }
