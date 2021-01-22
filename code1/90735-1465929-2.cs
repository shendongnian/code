    private static readonly Type ThisType = typeof(MyDependencyObject<TypeA, TypeB, TypeC, TypeD>));
    
    public int MyProperty1
    {
      get { return (int)GetValue(MyPropertyProperty1); }
      set { SetValue(MyPropertyProperty1, value); }
    }
    
    public static readonly DependencyProperty MyPropertyProperty1 = 
        DependencyProperty.Register(GetPropertyName((MyDependencyObject x) => x.MyProperty1), typeof(int), ThisType);
