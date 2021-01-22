    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        CheckBox.IsCheckedProperty.OverrideMetadata(typeof(CheckBox),
            new FrameworkPropertyMetadata(true));
    }
