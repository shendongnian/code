        private void Form1_Load(object sender, EventArgs e)
        {
            // set image location
            imgOriginal = new Bitmap(Image.FromFile(@"C:\images\TestImage.bmp"));
            picBox.Image = imgOriginal;
            // set Picture Box Attributes
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            // set Slider Attributes
            zoomSlider.Minimum = 1;
            zoomSlider.Maximum = 5;
            zoomSlider.SmallChange = 1;
            zoomSlider.LargeChange = 1;
            zoomSlider.UseWaitCursor = false;
            SetPictureBoxSize();
            // reduce flickering
            this.DoubleBuffered = true;
        }
        // picturebox size changed triggers paint event
        private void SetPictureBoxSize()
        {
            Size s = new Size(Convert.ToInt32(imgOriginal.Width * zoomSlider.Value), Convert.ToInt32(imgOriginal.Height * zoomSlider.Value));
            picBox.Size = s;
        }
        // looks for user trackbar changes
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (zoomSlider.Value > 0)
            {
                SetPictureBoxSize();
            }
        }
        // redraws image using nearest neighbour resampling
        private void picBox_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(
               imgOriginal,
                new Rectangle(0, 0, picBox.Width, picBox.Height),
                // destination rectangle 
                0,
                0,           // upper-left corner of source rectangle
                imgOriginal.Width,       // width of source rectangle
                imgOriginal.Height,      // height of source rectangle
                GraphicsUnit.Pixel);
        }
