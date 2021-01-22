    static NumericTextBox()
    {
        TextProperty.OverrideMetadata(
            typeof(NumericTextBox),
            new FrameworkPropertyMetadata("", // default value
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                null,  // property change callback
                null,  // coercion callback
                true,  // prohibits animation
                UpdateSourceTrigger.PropertyChanged));
    }
