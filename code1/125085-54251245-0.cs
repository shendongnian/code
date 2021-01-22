        public static void RotateImage(PictureBox picBox)
        {
            Image img = picBox.Image;
            var bmp = new Bitmap(img);
            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }
            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            picBox.Image = bmp;
        }
