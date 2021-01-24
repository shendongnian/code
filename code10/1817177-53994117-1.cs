     static void Main(string[] args)
        {
            SportTypeCollection sportTypes = new SportTypeCollection();
            sportTypes.Add(new SportType { Type = "a", Players = new List<Player> { new Player { Name = "p", Sport = "s" } } });
            sportTypes.Add(new SportType { Type = "b", Players = new List<Player> { new Player { Name = "p", Sport = "v" } } });
            Serialize<SportTypeCollection>(sportTypes, "d:\\message.xml", null, null);
        }
        public static void Serialize<T>(T instance, string fileName, IDataContractSurrogate dataContractSurrogate, params Type[] knownTypes)
        {
           
            DataContractSerializer serializer = new DataContractSerializer(typeof(T), knownTypes, int.MaxValue, false, false, dataContractSurrogate);
            using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                serializer.WriteObject(writer, instance);
            }
            Process.Start(fileName);
        }
