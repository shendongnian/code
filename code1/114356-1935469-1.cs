    public Form1()
    {
        InitializeComponent();
        tVideo.Start();
    }
    int i = 0;
    private void tVideo_Tick(object sender, EventArgs e)
    {
        String lFile = String.Format("c:\\{0}.bmp", i);
        SaveAsBitmap(this, lFile);
        i++;
    }
    public void SaveAsBitmap(Control aCtrl, string aFileName)
    {
        if (File.Exists(aFileName))
            File.Delete(aFileName);
        Graphics lGraphics = aCtrl.CreateGraphics();
        
        Bitmap lImage = new Bitmap(aCtrl.Width, aCtrl.Height);
        aCtrl.DrawToBitmap(lImage, new Rectangle(0, 0, aCtrl.Width, aCtrl.Height));
        lImage.Save(aFileName);
        lImage.Dispose();
    }
