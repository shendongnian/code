    using System.Web.Script.Serialization;
    var json = new JavaScriptSerializer().Serialize(GetXmlValues(XElement.Parse(xmlString)));
    private static Dictionary<string, object> GetXmlValues(XElement xml)
    {
        var attr = xml.Attributes().ToDictionary(d => d.Name.LocalName, d => (object)d.Value);
        if (xml.HasElements) attr.Add("_value", xml.Elements().Select(e => GetXmlValues(e)));
        else if (!xml.IsEmpty) attr.Add("_value", xml.Value);
        return new Dictionary<string, object> { { xml.Name.LocalName, attr } };
    }
