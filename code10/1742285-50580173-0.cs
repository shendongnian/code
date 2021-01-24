    public MyClass()
    {
      InitializeComponent();
      #if DEBUG
        ArrowRight.IsEnabled = false;
      #endif
    }
