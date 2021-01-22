      public event EventHandler InsideRectangles;
      private List<Rectangle> mRectangles = new List<Rectangle>();
      private bool mInside;
    
      protected void OnInsideRectangles(EventArgs e) {
        EventHandler handler = InsideRectangles;
        if (handler != null) handler(this, e);
      }
    
      protected override void OnMouseMove(MouseEventArgs e) {
        bool inside = false;
        foreach (var rc in mRectangles) {
          if (rc.Contains(e.Location)) {
            inside = true;
            break;
          }
        }
        if (inside && !mInside) OnInsideRectangles(EventArgs.Empty);
        this.Capture = inside;
        mInside = inside;
        base.OnMouseMove(e);
      }
