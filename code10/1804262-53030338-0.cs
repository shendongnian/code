    List<PropertyInfo> _props = new List<PropertyInfo>();
.
    namespace WpfApplication3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        /// 
    
        class MyClass
        {
            [AttributeType]
            public string SomeString { get; set; }
    
            public MySecondClass MySecondClass { get; set; }
        }
    
        class MySecondClass
        {
            [AttributeType]
            public string SomeString { get; set; }
        }
    
        class AttributeType : Attribute
        {
    
        }
        
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                CollectProperties(typeof (MyClass));
                InitializeComponent();
            }
    
            List<PropertyInfo> _props = new List<PropertyInfo>();
    
            public void CollectProperties(Type myType)
            {
                IEnumerable<PropertyInfo> properties = myType.GetProperties().Where(
                    property => Attribute.IsDefined(property, typeof(AttributeType)));
    
    
                foreach (var propertyInfo in properties)
                {
                    if (!_props.Any((pr => pr.DeclaringType.FullName == propertyInfo.DeclaringType.FullName)))
                    {
                        _props.Add(propertyInfo);
                    }
                }
                
    
                var props = myType.GetProperties();
    
                foreach (var propertyInfo in props)
                {
                    CollectProperties(propertyInfo.PropertyType);
                }
            }
        }
    }
