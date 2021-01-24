    public sealed class KeyValueHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            var result = new List<KeyValuePair<string, string>>();
            foreach (XmlNode child in section.ChildNodes)
            {
                var key = child.Attributes["key"].Value;
                var value = child.Attributes["value"].Value;
                result.Add(new KeyValuePair<string, string>(key, value));
            }
            return result;
        }
    }
