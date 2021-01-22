    class A : DependencyObject
        {
            public int X
            {
                get { return (int)GetValue(XProperty); }
                set { SetValue(XProperty, value); }
            }
            public static readonly DependencyProperty XProperty = DependencyProperty.Register("X", typeof(int), typeof(A), new UIPropertyMetadata(0));
        }
    
        class B : DependencyObject
        {
            public int X
            {
                get { return (int)GetValue(XProperty); }
                set { SetValue(XProperty, value); }
            }
            public static readonly DependencyProperty XProperty = DependencyProperty.Register("X", typeof(int), typeof(B), new UIPropertyMetadata(0));
        }
    
        class C : DependencyObject
        {
            A a = new A();
            B b = new B();
            public int X
            {
                get { return a.X; }
                set { a.X = value; }
            }
            public int Y
            {
                get { return b.X; }
                set { b.X = value; }
            }
        }
