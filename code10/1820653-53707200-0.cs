    private Point pointToDrawRect = new Point(0,0);
    public void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            String data = (x.ToString() + " " + y.ToString());
            pointToDrawRect= new Point(x, y);
            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
             if(pointToDrawRect.X != 0 || pointToDrawRect.Y != 0)
             {
                 DrawRect(e, pointToDrawRect.X, pointToDrawRect.Y);
             }
        }
        public void DrawRect(PaintEventArgs e, int rey, int rex)
        {
                using (Pen pen = new Pen(Color.Azure, 4))
                {
                    Rectangle rect = new Rectangle(0, 0, rex, rey);
                    e.Graphics.DrawRectangle(pen, rect);
                }
        }
