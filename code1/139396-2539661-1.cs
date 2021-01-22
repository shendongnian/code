    public SomeClass : DependencyObject
    {
      static DependencyPropertySynchronizer sync =
        new DependencyPropertySynchronizer
        {
          Priority = DispatcherPriority.ApplicationIdle
        };
 
      public static readonly DependencyProperty HappinessProperty =
       sync.RegisterAttached("Happiness", typeof(int), typeof(SomeClass));
      public static readonly DependencyProperty JoyProperty =
       sync.RegisterAttached("Joy", typeof(int), typeof(SomeClass));
    }
