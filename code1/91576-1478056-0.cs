    public Point GetPositionInForm(Control ctrl)
    {
       Point p = ctrl.Location;
       Control parent = ctrl.Parent;
       while (! (parent is Form))
       {
          p.Offset(parent.Location.X, parent.Location.Y);
          parent = parent.Parent;
       }
       return p;
    }
