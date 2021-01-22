    public static class XmlNodeExtensions
    {
        public static bool TrySelectSingleNode(this XmlNode node,
                                               string xpath,
                                               out XmlNode result)
        {
            result = node.SelectSingleNode(xpath);
            return (result != null);
        }
    }
