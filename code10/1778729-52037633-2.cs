        VideoCaptureDevice videoSource = new VideoCaptureDevice(LoaclWebCamsCollection["Select webcam you want to user"].MonikerString);
                          OR
        VideoCaptureDevice videoSource = new VideoCaptureDevice(LoaclWebCamsCollection[0].MonikerString);
        
    private void Start_Vid()
    {
        FinalVideo = new 
        VideoCaptureDevice(LoaclWebCamsCollection[0].MonikerString);
        FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
        FinalVideo.Start();
    }
