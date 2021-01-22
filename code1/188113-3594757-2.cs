    private Point p1, p2;
    List<Point> p1List = new List<Point>();
    List<Point> p2List = new List<Point>();
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (p1.X == 0)
            {
                p1.X = e.X;
                p1.Y = e.Y;
            }
            else
            {
                p2.X = e.X;
                p2.Y = e.Y;
                p1List.Add(p1);
                p2List.Add(p2);
                Invalidate();
                p1.X = 0;
            }
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            using(var p = new Pen(Color.Blue, 4))
            {
                for(int x = 0; x<p1List.Count; x++){
                    e.Graphics.DrawLine(p, p1List[x], p2List[x]);
                }
            }
        }
