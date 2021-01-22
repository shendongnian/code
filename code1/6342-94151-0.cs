    Point lastPoint = Point.Empty;
    Panel leftResizer = new Panel();
    leftResizer.Cursor = System.Windows.Forms.Cursors.SizeWE;
    leftResizer.Dock = System.Windows.Forms.DockStyle.Left;
    leftResizer.Size = new System.Drawing.Size(1, 100);
    leftResizer.MouseDown += delegate(object sender, MouseEventArgs e) { 
      lastPoint = leftResizer.PointToScreen(e.Location); 
      leftResizer.Capture = true;
    }
    leftResizer.MouseMove += delegate(object sender, MouseEventArgs e) {
      if (lastPoint != Point.Empty) {
        Point newPoint = leftResizer.PointToScreen(e.Location);
        Location = new Point(Location.X + (newPoint.X - lastPoint.X), Location.Y);
        Width = Math.Max(MinimumSize.Width, Width - (newPoint.X - lastPoint.X));
        lastPoint = newPoint;
      }
    }
    leftResizer.MouseUp += delegate (object sender, MouseEventArgs e) { 
      lastPoint = Point.Empty;
      leftResizer.Capture = false;
    }
    
    form.BorderStyle = BorderStyle.None;
    form.Add(leftResizer);
