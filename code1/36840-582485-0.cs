    void canvas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        int ClickMargin = 2;
        Point ClickedPoint = e.GetPosition(canvas1);
        Point p1 = new Point(ClickedPoint.X - ClickMargin, ClickedPoint.Y - ClickMargin);
        Point p2 = new Point(ClickedPoint.X - ClickMargin, ClickedPoint.Y + ClickMargin);
        Point p3 = new Point(ClickedPoint.X + ClickMargin, ClickedPoint.Y + ClickMargin);
        Point p4 = new Point(ClickedPoint.X + ClickMargin, ClickedPoint.Y - ClickMargin);
        var PointPickList = new Collection<Point>();
        PointPickList.Add(ClickedPoint);
        PointPickList.Add(p1);
        PointPickList.Add(p2);
        PointPickList.Add(p3);
        PointPickList.Add(p4);
    
        foreach (Point p in PointPickList)
        {
            HitTestResult SelectedCanvasItem = System.Windows.Media.VisualTreeHelper.HitTest(canvas1, p);
            if (SelectedCanvasItem.VisualHit.GetType() == typeof(Ellipse))
            {
                var SelectedEllipseTag = SelectedCanvasItem.VisualHit.GetValue(Ellipse.TagProperty);
                if (SelectedEllipseTag!=null &&  SelectedEllipseTag.GetType().BaseType == typeof(Hole))
                {
                    Hole SelectedHole = (Hole)SelectedEllipseTag;
                    SetActivePattern(SelectedHole.ParentPattern);
                    SelectedHole.ParentPattern.CurrentHole = SelectedHole;
    
                }
            }
        }
    }
