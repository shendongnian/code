    public class Asset
    {
        public static bool TryParse(XElement element, out Asset asset)
        {
            var serializer = new XmlSerializer(typeof(Asset));
            var reader = element.CreateReader();
            var result = serializer.CanDeserialize(reader));
            asset = result
                ? (Asset)serializer.Deserialize(reader)
                : default(Asset);
    
            return result;
        }
    }
