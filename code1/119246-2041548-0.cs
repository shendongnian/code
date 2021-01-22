    bool mLoaded;
    protected override void SetVisibleCore(bool value) {
      if (value && !mLoaded) {
        this.CreateHandle();   // Ensure the Load event runs
        value = false;         // Keep invisible
        mLoaded = true;
      }
      base.SetVisibleCore(value);
    }
