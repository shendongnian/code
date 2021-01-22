        private void loadImage(string path) {
            using (var srce = new Bitmap(path)) {
                var dest = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                using (var gr = Graphics.FromImage(dest)) {
                    gr.DrawImage(srce, new Rectangle(Point.Empty, dest.Size));
                }
                if (pictureBox1.Image != null) pictureBox1.Dispose();
                pictureBox1.Image = dest;
            }
        }
