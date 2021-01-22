     Bitmap bmp = new Bitmap(pictureBox1.Image);
            int width = bmp.Width;
            int height = bmp.Height;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color color = bmp.GetPixel(x, y);
                    if (color.R == 0)
                    {
                        textBox4.Text = x.ToString();
                        textBox5.Text = y.ToString();
                        return; //Starting Point.If canceled endpoint.
                    }
