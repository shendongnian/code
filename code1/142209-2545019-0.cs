    protected override void SetVisibleCore(bool value) {
      if (!this.IsHandleCreated) {
        this.CreateHandle();
        value = false;  // Prevent becoming visible the first time
      }
      base.SetVisibleCore(value);
    }
