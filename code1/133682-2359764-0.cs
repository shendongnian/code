    public Form1() {
      dude[0] = new Bitmap(@"C:\Directory.bmp");
      InitializeComponent();
      this.SetStyle( System.Windows.Forms.ControlStyles.UserPaint, true );
      this.SetStyle( System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true );
      this.SetStyle( System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true );
    }
