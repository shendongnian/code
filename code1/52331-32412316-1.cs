    using System.Web.Script.Serialization;
    var json = new JavaScriptSerializer().Serialize(GetXmlData(XElement.Parse(xmlString)));
    private static Dictionary<string, object> GetXmlData(XElement xml)
    {
        var attr = xml.Attributes().ToDictionary(d => d.Name.LocalName, d => (object)d.Value);
        if (xml.HasElements) attr.Add("_value", xml.Elements().Select(e => GetXmlData(e)));
        else if (!xml.IsEmpty) attr.Add("_value", xml.Value);
        return new Dictionary<string, object> { { xml.Name.LocalName, attr } };
    }
