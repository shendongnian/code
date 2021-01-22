     private void btnCrop_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            try
            {
                if (cropWidth < 1)
                {
                    return;
                }
                Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                //First we define a rectangle with the help of already calculated points
                Bitmap OriginalImage = new Bitmap(picBoxScreenshot.Image, picBoxScreenshot.Width, picBoxScreenshot.Height);
                //Original image
                Bitmap _img = new Bitmap(cropWidth, cropHeight);
                // for cropinfo image
                Graphics g = Graphics.FromImage(_img);
                // create graphics
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                //set image attributes
                g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
                picBox.Image = _img;
                picBox.Width = _img.Width;
                picBox.Height = _img.Height;
                PictureBoxLocation();
                cropWidth = 0;
            }
            catch (Exception ex){}
        }
     private void PictureBoxLocation()
        {
            int _x = 0;
            int _y = 0;
            if (panel1.Width > picBox.Width)
            {
                _x = (panel1.Width - picBox.Width) / 2;
            }
            if (panel1.Height > picBox.Height)
            {
                _y = (panel1.Height - picBox.Height) / 2;
            }
            picBox.Location = new Point(_x, _y);
            picBox.Refresh();
        }
