        public static Bitmap CombineBitmap(string[] files)
        {
            //change the location to store the final image.
            Bitmap img = new Bitmap(files[0]);
            Bitmap img3 = new Bitmap(img.Width, img.Height);
            Graphics g = Graphics.FromImage(img3);
            g.Clear(SystemColors.AppWorkspace);
            foreach (string file in files)
            {
                 img = new Bitmap(file);
               
                img.MakeTransparent(Color.White);
                g.DrawImage(img, new Point(0, 0));
                //img3.MakeTransparent(Color.White);
                
            }
            using (var b = new Bitmap(img3.Width, img3.Height))
            {
                b.SetResolution(img3.HorizontalResolution, img3.VerticalResolution);
                using (var g2 = Graphics.FromImage(b))
                {
                    g2.Clear(Color.White);
                    g2.DrawImageUnscaled(img3, 0, 0);
                }
                // Now save b as a JPEG like you normally would
                return img3;
            }
