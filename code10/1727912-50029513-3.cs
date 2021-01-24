        Pen usedpen= new Pen(Color.Black, 2);
        //Point[] p = {
        //    new Point(518,10),
        //    new Point(518,20),
        //    new Point(518-85,15)
        //};
        GraphicsPath path = new GraphicsPath();
        path.StartFigure();
        path.AddLine(new Point(518, 10), new Point(433, 10));
        path.StartFigure();   // <---
        path.AddLine(new Point(518, 40), new Point(433, 40));
        path.StartFigure();   // <---
        path.AddLine(new Point(433,10), new Point(433,40));
        //usedpen.LineJoin = LineJoin.Round;
        e.Graphics.DrawPath(usedpen, path);
