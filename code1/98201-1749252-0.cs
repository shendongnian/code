    var pen = new Pen(Color.Red, 3);
    var graphics = this.CreateGraphics();
    var mouseMoveWhileDown = 
        from md in this.GetMouseDown()
        from mv in this.GetMouseMove().Until(this.GetMouseUp())
        select new Point(mv.X, mv.Y);
    mouseMoveWhileDown
        .Pairwise()
        .Subscribe(tup => graphics.DrawLine(pen, tup.Item1, tup.Item2)); 
