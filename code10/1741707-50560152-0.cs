            Bitmap OrgImage = new Bitmap(file);
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(OrgImage, 0, 0, newWidth, newHeight);
            }
            pictureBox1.Image = newImage;
