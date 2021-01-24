    /// <summary>
    /// Set the visual State of the page
    /// </summary>
    public ESecurePageVisualState VisualState
    {
        get => (ESecurePageVisualState)GetValue(VisualStateProperty);
        set => SetValue(VisualStateProperty, value);
    }
    /// <summary>
    /// The <see cref="VisualState"/> DependencyProperty.
    /// </summary>
    public static readonly DependencyProperty VisualStateProperty = DependencyProperty.Register("VisualState", typeof(ESecurePageVisualState), typeof(SecurePage), new PropertyMetadata(ESecurePageVisualState.Normal));
