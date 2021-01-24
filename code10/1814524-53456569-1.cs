            private void pbImage_MouseDown(object sender, MouseEventArgs e)
            {
                mouseDown = true;
                
            }
    
            private void drawPictureBox_MouseMove(object sender, MouseEventArgs e)
            {
                if (mouseDown)
                {
                    Point point = drawPictureBox.PointToClient(Cursor.Position);
                    DrawPoint((point.X), (point.Y));
                }
            }
    
            private void drawPictureBox_MouseUp(object sender, MouseEventArgs e)
            {
                mouseDown = false;
            }
    
            public void DrawPoint(int x, int y)
            {
                
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    SolidBrush brush = new SolidBrush(Color.White);
                    g.FillRectangle(brush, x, y, 5, 5);
                }
                drawPictureBox.Image = bitmap;
            }
            private void zoomImage(Bitmap bitmap)
            {
                var result = new Bitmap(28,28);
                using (Graphics g1 = Graphics.FromImage(bitmap))
                {
                    g1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g1.DrawImage(result, 0, 0, 28, 28);
                }
                pictureBox1.Image = result;
    
            }
