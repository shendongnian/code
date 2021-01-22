    public Form1 ( )
    {
        InitializeComponent ( );
    
         Bitmap bmp = null;
         using (Stream stream = File.OpenRead(@"C:\temp\pretty.bmp"))
         {
             bmp = new Bitmap(stream);
         }
    
         using (Graphics g = Graphics.FromImage ( bmp ))
         using (Brush b = new SolidBrush ( Color.Red ))
         {
             g.FillRectangle ( b, 0, 0, 49, 49 );
         }
         bmp.Save ( @"C:\temp\pretty.bmp" );
         this.pictureBox1.Image = bmp;
    }
