    public class XmlSerializerFactory
    {
        public XmlSerializer GetSerializerFor<T>()
        {
            lock (this)
            {
                Type typeOfT = typeof(T);
                if (false == serializers.ContainsKey(typeOfT))
                {
                    XmlSerializer newSerializer = new XmlSerializer(typeOfT);
                    serializers.Add(typeOfT, newSerializer);
                }
                return serializers[typeOfT];
            }
        }
        private Dictionary<Type, XmlSerializer> serializers = new Dictionary<Type, XmlSerializer>();
    }
