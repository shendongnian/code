    public class XmlDeserializer<T>
         where T : class
    {
        // "Globally" caches T => Dictionary<xmlelementnames, type>
        private static readonly ConcurrentDictionary<Type, IDictionary<string, Type>> _typecache = new ConcurrentDictionary<Type, IDictionary<string, Type>>();
        // We store instances of serializers per type T in this pool so we need not create a new one each time
        private static readonly ConcurrentDictionary<Type, XmlSerializer> _serializers = new ConcurrentDictionary<Type, XmlSerializer>();
        // And all serializers get the same instance of XmlReaderSettings which, again saves creating objects / garbage collecting.
        private static readonly XmlReaderSettings _readersettings = new XmlReaderSettings() { IgnoreWhitespace = true };
        // Lookup for current T, with this we keep a reference for the current T in the global cache so we need one less dictionary lookup
        private readonly IDictionary<string, Type> _thistypedict;
        public XmlDeserializer()
        {
            // Enumerate T's XmlInclude attributes
            var includes = ((IEnumerable<XmlIncludeAttribute>)typeof(T).GetCustomAttributes(typeof(XmlIncludeAttribute), true));
            // Get all the mappings
            var mappings = includes.Select(a => new
            {
                a.Type,
                ((XmlRootAttribute)a.Type.GetCustomAttributes(typeof(XmlRootAttribute), true).FirstOrDefault())?.ElementName
            }).Where(m => !string.IsNullOrEmpty(m.ElementName));
            // Store all mappings in our current instance and at the same time store the mappings for T in our "global cache"
            _thistypedict = _typecache.GetOrAdd(typeof(T), mappings.ToDictionary(v => v.ElementName, v => v.Type));
        }
        public T Deserialize(string input)
        {
            // Read our input
            using (var stringReader = new StringReader(input))
            using (var xmlReader = XmlReader.Create(stringReader, _readersettings))
            {
                xmlReader.MoveToContent();
                // Make sure we know how to deserialize this element
                if (!_thistypedict.TryGetValue(xmlReader.Name, out var type))
                    throw new InvalidOperationException($"Unable to deserialize type '{xmlReader.Name}'");
                // Grab serializer from pool or create one if required
                var serializer = _serializers.GetOrAdd(type, (t) => new XmlSerializer(t, new XmlRootAttribute(xmlReader.Name)));
                // Finally, now deserialize...
                return (T)serializer.Deserialize(xmlReader);
            }
        }
    }
