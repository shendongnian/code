    [ContentProperty("Content")]
    sealed class Fragment : FrameworkElement
    {
      public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
        nameof(Content),
        typeof(FrameworkContentElement),
        typeof(Fragment));
    
      public FrameworkContentElement Content
      {
        get => (FrameworkContentElement)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
      }
    }
