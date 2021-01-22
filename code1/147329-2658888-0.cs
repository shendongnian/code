    public bool CouldBeVisible { get; set; }
    protected override void SetVisibleCore(bool value) {
      CouldBeVisible = value;
      base.SetVisibleCore(value);
    }
