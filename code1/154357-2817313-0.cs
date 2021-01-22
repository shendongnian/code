    public static readonly DependencyProperty MyIntegerProperty = 
        DependencyProperty.Register("MyInteger", typeof(Integer), typeof(MyControl));
     
    public int MyInteger
    {
        get { return (int)GetValue(MyIntegerProperty); }
        set { SetValue(MyIntegerProperty, value); }
    }
