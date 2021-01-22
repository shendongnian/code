    static void Main(string[] args)
    {
        XmlDocument xmldoc = new XmlDocument();
        xmldoc.LoadXml("<a><b /><b /><b /></a>");
        XmlNodeList xmlNodeList = xmldoc.SelectNodes("//b");
        XmlNode[] array = (
            new System.Collections.Generic.List<XmlNode>(
                Shim<XmlNode>(xmlNodeList))).ToArray();
    }
    public static IEnumerable<T> Shim<T>(System.Collections.IEnumerable enumerable)
    {
        foreach (object current in enumerable)
        {
            yield return (T)current;
        }
    }
