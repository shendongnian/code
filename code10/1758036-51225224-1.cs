        private void pb_Bezier_Paint(object sender, PaintEventArgs e)
        {
            Point P1 = new Point(10, 300);
            Point P2 = new Point(180, 50);
            Point P3 = new Point(320, 300);
            ZeichneBezier(6, P1, P2, P3, e, true);
        }
        private void ZeichneBezier(int n, Point P1, Point P2, Point P3, PaintEventArgs pva, bool initial)
        {
            Graphics g = pva.Graphics;
            Pen bkStift = new Pen(Color.Red, 2);
            Pen kpStift = new Pen(Color.Black, 3);
            if(initial)
            {
                g.DrawLine(kpStift, P1, P2);
                g.DrawLine(kpStift, P2, P3);
            }
            if (n > 0)
            {
                Point P12 = new Point((P1.X + P2.X) / 2, (P1.Y + P2.Y) / 2);
                Point P23 = new Point((P2.X + P3.X) / 2, (P2.Y + P3.Y) / 2);
                Point P123 = new Point((P12.X + P23.X) / 2, (P12.Y + P23.Y) / 2);
                ZeichneBezier(n - 1, P1, P12, P123, pva, false);
                ZeichneBezier(n - 1, P123, P23, P3, pva, false);
            }
            else
            {
                g.DrawLine(bkStift, P1, P2);
                g.DrawLine(bkStift, P2, P3);
            }
        }
