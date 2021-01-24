    ParserContext parserContext = new ParserContext();
    parserContext.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
    parserContext.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
    parserContext.XmlnsDictionary.Add("cust", "clr-namespace:App1.Customers;assembly=" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
    const string Xaml = "<DataTemplate>" +
                            "<cust:CustomerView />" +
                         "</DataTemplate>";
    Resources.Add(new DataTemplateKey(typeof(CustomerViewModel)), 
                  XamlReader.Parse(Xaml, parserContext) as DataTemplate);
