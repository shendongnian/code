    var xPathDocument = new XPathDocument("myfile.xml");
    var query = XPathExpression.Compile(@"/abc/foo[contains(text(),""testing"")]");
    
    var navigator = xpathDocument.CreateNavigator();
    var iterator = navigator.Select(query);
    while(iterator.MoveNext())
    {
        Console.WriteLine(iterator.Current.Name);    
        Console.WriteLine(iterator.Current.Value);    
    }
