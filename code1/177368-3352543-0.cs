    public int Test {
        get { return (int)GetValue(TestProperty); }
        set { SetValue(TestProperty, value); }
    }
    
            
    public static readonly DependencyProperty TestProperty =
        DependencyProperty.Register("Test", typeof(int), typeof(YourClass), 
        new UIPropertyMetadata(0), delegate(object v) { 
          return ((int)v) > 0; // Here you can check the value set to the dp
        });
