    public static class Extensions
    {
       public static String SafeInnerText(this XmlElement node, String default)
       {
          return (node != null) ? node.InnerText : default;
       }
    }
