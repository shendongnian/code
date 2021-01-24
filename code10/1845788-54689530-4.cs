    public IEnumerable<bool> PartFlags
    {
        get { return (bool[])GetValue(PartFlagsProperty); }
        set { SetValue(PartFlagsProperty, value); }
    }
    // Using a DependencyProperty as the backing store for PartFlags.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PartFlagsProperty =
        DependencyProperty.Register("PartFlags", typeof(bool[]), typeof(MyFormattedTextControl), new PropertyMetadata(new bool[] { false, false, false, false }));
