    private bool mAllowVisible = false;
    public bool ReallyVisible {
      get { return mAllowVisible; }
      set {
        mAllowVisible = value;
        if (value) this.Visible = true;
      }
    }
    protected override void SetVisibleCore(bool value) {
      if (value && !IsHandleCreated) CreateHandle();  // Ensure Load event runs
      if (!ReallyVisible) value = false;
      base.SetVisibleCore(value);
    }
