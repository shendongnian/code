    // Note callback in PropertyMetadata
    public static readonly DependencyProperty CommandProperty =
      DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(Click),
      new PropertyMetadata(OnCommandChanged));
    // GetXxx and SetXxx wrappers contain boilerplate only
    public static ICommand GetCommand(DependencyObject obj)
    {
      return (ICommand)obj.GetValue(CommandProperty);
    }
    public static void SetCommand(DependencyObject obj, ICommand value)
    {
      obj.SetValue(CommandProperty, value);
    }
    // WPF will call the following when the property is set, even when it's set in XAML
    private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      ButtonBase button = d as ButtonBase;
      if (button != null)
      {
        // do something with button.Click here
      }
    }
