    public static class XmlTools
    {
      public static IEnumerable<string> ToXmlString<T>(this IEnumerable<T> inputs)
      {
         return inputs.Select(pArg => pArg.ToXmlString());
      }
    }
