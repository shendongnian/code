    public DateTime SelectedDateTime
    {
        get { return (DateTime)GetValue(SelectedDateTimeProperty); }
        set { SetValue(SelectedDateTimeProperty, value); }
    }
    // Using a DependencyProperty as the backing store for SelectedDateTime. This enables animation, styling, binding, etc...
    public static readonly DependencyProperty SelectedDateTimeProperty =
    DependencyProperty.Register("SelectedDateTime", typeof(DateTime), typeof(YourModel), new PropertyMetadata(DateTime.Now));
