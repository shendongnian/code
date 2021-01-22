    public static class Extensions
    {
      public static string ToString(this XmlDocument xmlDoc)
      {
        StringWriter sw = new StringWriter();
        XmlTextWriter tx = new XmlTextWriter(sw);
        xmlDoc.WriteTo(tx);
        string strXmlText = sw.ToString();
        return strXmlText;
      }
    }
