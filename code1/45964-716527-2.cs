    public Window()
    {
        InitializeComponent();
    
        ThreadPool.QueueUserWorkItem(LoadImage,
             "http://z.about.com/d/animatedtv/1/0/1/m/simp2006_HomerArmsCrossed_f.jpg");
    }
    
    public void LoadImage(object uri)
    {
        var decoder = new JpegBitmapDecoder(new Uri(uri.ToString()), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
        decoder.Frames[0].Freeze();
        this.Dispatcher.Invoke(DispatcherPriority.Send, new Action<ImageSource>(SetImage), decoder.Frames[0]);
    }
    
    public void SetImage(ImageSource source)
    {
        this.BackgroundImage.Source = source;
    }
