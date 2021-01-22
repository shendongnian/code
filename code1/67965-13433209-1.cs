        public Form1()
        {
            InitializeComponent();
            pBox.Image = new Bitmap(pBox.Width, pBox.Height);  
        }
        private void DrawStuff1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pBox.Image);  
            Graphics g = Graphics.FromImage(bmp);
            
            g.FillRectangle(Brushes.Red, 5, 5, 25, 25); //hard-coded size to reduce clutter
            
            pBox.Image = bmp;  //this makes your changes visible
        }
        private void Save_Click(object sender, EventArgs e)
        {
            pBox.Image.Save(appPath + "SavedImage.bmp");
        }
