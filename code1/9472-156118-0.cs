     public Form1()
            {
                InitializeComponent();
                Bitmap bmp = WindowsFormsApplication10.Properties.Resources.glider;
                this.Icon = Icon.FromHandle(bmp.GetHicon());
            }
