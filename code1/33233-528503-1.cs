    private static void MyPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        TestControl tc = d as TestControl;
        Binding myBinding = new Binding("MyDataProperty");
        myBinding.Mode = BindingMode.TwoWay;
        myBinding.Path = new PropertyPath(tc.MyPath);
        tc.txtBox.SetBinding(TextBox.TextProperty, myBinding);
    }
    public static readonly DependencyProperty MyPathProperty =
        DependencyProperty.Register("MyPath",
            typeof(string),
            typeof(TestControl),
            new PropertyMetadata("", MyPathChanged));
