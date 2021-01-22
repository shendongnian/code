    System.Drawing.Imaging.Metafile metaFile;
    public Form1()
    {
       InitializeComponent();
       using(Graphics g = Graphics.FromHwnd(this.Handle))
       {
          IntPtr hdc = g.GetHdc();
          try
          {
             metaFile = new System.Drawing.Imaging.Metafile(hdc, System.Drawing.Imaging.EmfType.EmfPlusOnly);
          }
          finally
          {
             g.ReleaseHdc(hdc);
          }
       }
       using (Graphics g = Graphics.FromImage(metaFile))
       {
          g.RotateTransform(45);
          g.DrawString("Test", this.Font, SystemBrushes.WindowText, 0, 0);
       }
    }
    protected override void OnPaint(PaintEventArgs e)
    {
       base.OnPaint(e);
       e.Graphics.DrawImage(metaFile, 20, 20);
       e.Graphics.DrawImage(metaFile, 30, 30);
       e.Graphics.EnumerateMetafile(metaFile, Point.Empty, MetafileCallback);
    }
    private bool MetafileCallback(System.Drawing.Imaging.EmfPlusRecordType type, int flags, int dataSize, IntPtr data, System.Drawing.Imaging.PlayRecordCallback callbackData)
    {
       System.Diagnostics.Debug.WriteLine(string.Format("{0} {1}", type, flags));
       return true;
    }
