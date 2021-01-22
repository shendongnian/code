        protected override void OnMouseDown(MouseEventArgs e)
        {
            Point pnt = this.PointToScreen(e.Location);
            base.OnMouseDown(new MouseEventArgs(e.Button, e.Clicks, pnt.X, pnt.Y, e.Delta));
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point pnt = this.PointToScreen(e.Location);
            base.OnMouseMove(new MouseEventArgs(e.Button, e.Clicks, pnt.X, pnt.Y, e.Delta));
        }
