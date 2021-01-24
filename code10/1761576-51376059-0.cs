    [Obsolete("Use something else")]
    public new Visibility Visibility
    {
    	get { return (Visibility)GetValue(VisibilityProperty); }
    	set { SetValue(VisibilityProperty, value); }
    }
    
    [Obsolete("Use something else")]
    public new static readonly DependencyProperty VisibilityProperty =
    	DependencyProperty.Register(nameof(Visibility), typeof(Visibility), typeof(YourCustomControl), new PropertyMetadata(0));
