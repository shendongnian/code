    protected override void OnMouseEnter(MouseEventArgs e)
    {
      base.OnMouseEnter(e);
      if (IsFadeEnabled)
      {
        fadeInStoryboard.Begin(this);
      }
    }
