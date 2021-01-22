    public class CustomerTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item,
                                                    DependencyObject container)
        {
            DataTemplate template = null;
            if (item != null)
            {
                FrameworkElement element = container as FrameworkElement;
                if (element != null)
                {
                    string templateName = item is ObservableCollection<MyCustomer> ?
                        "MyCustomerTemplate" : "YourCustomerTemplate";
                    template = element.FindResource(templateName) as DataTemplate;
                } 
            }
            return template;
        }
    }
    public class MyCustomer
    {
        public string CustomerName { get; set; }
    }
    public class YourCustomer
    {
        public string CustomerName { get; set; }
    }
