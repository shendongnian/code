    using System.Xml;
[...]
    XmlTextReader xtr = new XmlTextReader(GetResourceStream("config.xml"));
    while (xtr.Read())
    {
    if (xtr.AttributeCount == 0)
        continue;
    if (xtr.LocalName == "Configuration")
    {
        string version = xtr.GetAttribute("version");
        string date = xtr.GetAttribute("createDate");
        Console.WriteLine($"version={version} - date = {date}")
    }
    else if (xtr.LocalName == "AutoScale")
    {
        string autoscale = xtr.ReadString();
        Console.WriteLine($"autoscale={autoscale}")
    }
