    public override Color BackColor {
      get {
        return base.BackColor;
      }
      set {
        base.BackColor = value;
        CurrentBackColor = value;
        this.Invalidate();
      }
    }
