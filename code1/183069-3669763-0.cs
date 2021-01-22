    protected override void OnMouseHover(EventArgs e)
    {
      ToolTip myToolTip = new ToolTip();
      myToolTip.IsBalloon = true;
      // TODO The x and y coordinates should be what ever you wish.
      myToolTip.Show("Helpful Text Also", this, 50, 50);
      base.OnMouseHover(e);
    }
