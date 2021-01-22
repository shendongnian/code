    public static int GetSomething(DependencyObject d)
    {
    	return (int)d.GetValue(SomethingProperty);
    }
    
    public static void SetSomething(DependencyObject d, int value)
    {
    	d.SetValue(SomethingProperty, value);
    }
