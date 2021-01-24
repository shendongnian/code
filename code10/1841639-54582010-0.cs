    public Body()
            {
                InitializeComponent();
               
                    if (videoCapture == null)
                    {
                      
                        videoCapture = new Emgu.CV.VideoCapture(0);
                    }
                    videoCapture.ImageGrabbed += VideoCapture_ImageGrabbed;
                    videoCapture.Start();
    
                  
    
            }
    
            private void VideoCapture_ImageGrabbed(object sender, EventArgs e)
            {
                if (fileChanged)
                {
                    totalFrames = videoCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
                    fps = videoCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
                    int fourcc = Convert.ToInt32(videoCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FourCC));
                    int frameHeight = Convert.ToInt32(videoCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight));
                    int frameWidth = Convert.ToInt32(videoCapture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth));
                    string destination = "C:\\Users\\ITNOA\\Desktop\\savedVideoDHS\\" + i + ".avi";
                    videoWriter = new VideoWriter(destination, VideoWriter.Fourcc('I', 'Y', 'U', 'V'), fps, new Size(frameWidth, frameHeight), true);
                    fileChanged = false;
                }
    
               
                Mat m = new Mat();
                videoCapture.Retrieve(m);
                pictureBox1.Image = m.ToImage<Bgr, byte>().Bitmap;
                videoWriter.Write(m);
            }
