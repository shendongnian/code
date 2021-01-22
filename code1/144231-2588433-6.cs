    public static class XmlSerializationExtension()
    {
        public static XmlDictionaryEntryCollection<TKey, TValue> AsXmlSerializable<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary != null)
                return new XmlDictionaryEntryCollection<TKey, TValue>(dictionary);
            else
                return null;
        }
    }
