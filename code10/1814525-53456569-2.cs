            List<KeyValuePair<int, int>> coordonateList = new List<KeyValuePair<int, int>>();
            ////
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
                    g.FillRectangle(brush, x, y, 10, 10);
                    coordonateList.Add(new KeyValuePair<int,int>(x/10,y/10));
                }
                drawPictureBox.Image = bitmap;
            }
            private void zoomImage(Bitmap bitmap)
            {
                var result = new Bitmap(28,28);
                using (Graphics g1 = Graphics.FromImage(result))
                {
                    SolidBrush brush = new SolidBrush(Color.White);
                   
                    foreach (var item in coordonateList)
                    {
                        g1.FillRectangle(brush, item.Key, item.Value, 1, 
                }
                pictureBox1.Image = result;
    
            }
