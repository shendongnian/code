    [ContentProperty("CustomNode")]
    public class MyBehavior : Behavior<CheckBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            binding = new Binding();
            binding.XPath = XPath + "/" + CustomNode.Name;
            binding.Mode = BindingMode.OneWay;
            binding.Converter = NodeAvailableConverter.Instance;
            AssociatedObject.SetBinding(CheckBox.IsCheckedProperty, binding);
            AssociatedObject.Click += new RoutedEventHandler(AssociatedObject_Click);
            SourceProv.Refresh();
	}
    
        void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            var parent = SourceProv.Document.SelectSingleNode(XPath);
            if(AssociatedObject.IsChecked==true)
            {
                var newelement = SourceProv.Document.CreateElement(CustomNode.Name);
                foreach (var at in CustomNode.Attributes)
                    newelement.SetAttribute(at.Name, at.Value);
                parent.AppendChild(newelement);
            }
            else if (AssociatedObject.IsChecked == false)            
                parent.RemoveChild(parent.SelectSingleNode(CustomNode.Name));
            SourceProv.Refresh();
            AssociatedObject.SetBinding(CheckBox.IsCheckedProperty, binding);
        }
    
        public XmlDataProvider SourceProv { get; set; }
        public Node CustomNode { get; set; }
        public String XPath { get; set; }
        private Binding binding { get; set; }
	}
    
    public class NodeAvailableConverter : IValueConverter
    {
        private static NodeAvailableConverter _instance;
        public static NodeAvailableConverter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NodeAvailableConverter();
                return _instance;
            }
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    [ContentProperty("Attributes")]
    public class Node
    {
        public string Name { get; set; }
        private List<Attribute> _attributes;
        public List<Attribute> Attributes { get 
        {
            if (_attributes == null)
                _attributes = new List<Attribute>();
            return _attributes;
        } }
    }
    public class Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
