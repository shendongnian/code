    public class Class1 : DependencyObject
    {
        public static DependencyProperty SomeFieldProperty = DependencyProperty.Register(
            "SomeField",
            typeof(Class2),
            typeof(Class1));
    
        public Class2 SomeField
        {
            get { return (Class2)GetValue(SomeFieldProperty); }
            set { SetValue(SomeFieldProperty, value); }
        }
    
        public Class1()
        {
            SomeField = new Class2();
        }
    }
    
    public class Class2 : DependencyObject
    {
        public static DependencyProperty AnotherFieldProperty = DependencyProperty.Register(
            "AnotherField",
            typeof(string),
            typeof(Class2));
    
        public string AnotherField
        {
            get { return (string)GetValue(AnotherFieldProperty); }
            set { SetValue(AnotherFieldProperty, value); }
        }
    
        public Class2()
        {
            AnotherField = "Default Value";
        }
    }
