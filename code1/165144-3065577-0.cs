    class MyHeaderedControl : ContentControl
    {
      public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        "Header",
        typeof(object),
        typeof(MyHeaderedControl),
        new PropertyMetadata());
      public MyHeaderedControl()
      {
        this.DefaultStyleKey = typeof(MyHeaderedControl);
      }
    }
