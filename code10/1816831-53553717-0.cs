    public static readonly DependencyProperty TextProperty = 
    DependencyProperty.Register("Text", typeof(String), typeof(PleaseWait), 
                                new PropertyMetadata("Loading in progress...", OnTextChanged));
    public string Text
    {
        get => (string)this.GetValue(TextProperty);
        set { this.SetValue(TextProperty, value); }
    }
    private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) 
    {
        var c = (PleaseWait) d;
        c.Caption.Text = c.Text;
    }
