    public static class Parser
    {
        private static string TryParseCommon(XElement element, string attributeName)
        {
            if (element.Attribute(attributeName) != null && !string.IsNullOrEmpty(element.Attribute(attributeName).Value))
            {
                return element.Attribute(attributeName).Value;
            }
            return null;
        }
        public static bool TryParse(XElement element, string attributeName, out string value)
        {
            value = TryParseCommon(element, attributeName);
            return true;
        }
        public static bool TryParse(XElement element, string attributeName, out int value)
        {
            return int.TryParse(TryParseCommon(element, attributeName), out value);
        }
        public static bool TryParse(XElement element, string attributeName, out bool value)
        {
            return bool.TryParse(TryParseCommon(element, attributeName), out value);
        }
    }
