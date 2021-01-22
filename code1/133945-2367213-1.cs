    private static readonly DependencyPropertyKey PrintCommandPropertyKey = DependencyProperty.RegisterReadOnly(
      "PrintCommand",
      typeof(ICommand),
      typeof(ExportPrintGridControl),
      new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
    public static readonly DependencyProperty PrintCommandProperty = PrintCommandPropertyKey.DependencyProperty;
    public ICommand PrintCommand
    {
        get { return (ICommand)GetValue(PrintCommandProperty); }
        private set { SetValue(PrintCommandPropertyKey, value); }
    }
