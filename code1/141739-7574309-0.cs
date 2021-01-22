    private Capture cap;
    Image<Bgr, Byte> frame;
    
    public CameraCapture()
    {
        InitializeComponent();
        cap= new Capture();
        cap.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_HEIGHT, height);
        cap.SetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FRAME_WIDTH, width);
    
        Application.Idle += ProcessFrame;
    }
    
    private void ProcessFrame(object sender, EventArgs arg)
    {
        frame = _capture.QueryFrame();
        grayFrame = frame.Convert<Gray, Byte>();
    }
    
    public Image<Bgr,byte> QueryFrame()
    {
        return frame.Copy();
    }
