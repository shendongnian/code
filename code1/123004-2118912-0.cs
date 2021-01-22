    public bool LimitTextIsEnabled {
        // Explicit comparison because CheckBox.IsChecked is nullable.
        get { return this.LimitIsChecked == true; }
        private set { }
    }
