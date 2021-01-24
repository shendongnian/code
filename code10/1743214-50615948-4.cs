    public Info Source
    {   
        get { return (Info)GetValue(SourceProperty); }
        set { SetValue(SourceProperty, value); }
    }
    
    public static readonly DependencyProperty SourceProperty =
        DependencyProperty.Register("Source", typeof(Info), typeof(MyUseerControl), new PropertyMetadata(0));
