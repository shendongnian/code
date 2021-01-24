        VideoCaptureDevice videoSource = new VideoCaptureDevice(LoaclWebCamsCollection["Select webcam you want to user"].MonikerString);
                          OR
        VideoCaptureDevice videoSource = new VideoCaptureDevice(LoaclWebCamsCollection[0].MonikerString);
        FinalVideo = captureDevice.VideoDevice;
        FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
        FinalVideo.Start();
            private void Start_Vid()
            {
                VideoCaptureDevice videoSource = new 
                VideoCaptureDevice(LoaclWebCamsCollection[0].MonikerString);
                FinalVideo = captureDevice.VideoDevice;
                FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                FinalVideo.Start();
            }
