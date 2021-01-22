    string xaml = "<DataTemplate><TextBlock Text=\"{Binding Name}\"/></DataTemplate>";
    MemoryStream sr = new MemoryStream(Encoding.ASCII.GetBytes(xaml));
    ParserContext pc = new ParserContext();
    pc.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
    pc.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
    DataTemplate datatemplate = (DataTemplate)XamlReader.Load(sr, pc);
    treeView1.Resources.Add("dt", datatemplate);
