    public static readonly DependencyProperty EMListProperty =
       DependencyProperty.Register(
       "EMList",
       typeof(ElementCollection),
       typeof(ListWrapper),
       new FrameworkPropertyMetadata(new ElementCollection())
     );
    public ElementCollection EMList
    {
        get { return (ElementCollection)GetValue(EMListProperty); }
        set { SetValue(EMListProperty, value); }
    }
