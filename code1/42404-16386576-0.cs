    public class Animals : List<Animal>, IXmlSerializable
    {
        private static Type[] _animalTypes;//for IXmlSerializable
        public Animals()
        {
            _animalTypes = GetAnimalTypes().ToArray();//for IXmlSerializable
        }
        // this static make you access to the same Animals instance in any other class.
        private static Animals _animals = new Animals();
        public static Animals animals
        {
            get {return _animals; }
            set { _animals = value; }
        }
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
                return;
            reader.MoveToContent();
            reader.ReadStartElement("Animals");
            // you MUST deserialize with 'List<Animal>', if Animals class has no 'List<Animal>' fields but has been derived from 'List<Animal>'.
            List<Animal> coll = GenericSerializer.Deserialize<List<Animal>>(reader, _animalTypes);
            // And then, You can set 'Animals' to 'List<Animal>'.
            _animals.AddRange(coll);
            reader.ReadEndElement();
            //Read Closing Element
            reader.ReadEndElement();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("Animals");
            // You change 'List<Animal>' to 'Animals' at first.
            List<Animal> coll = new List<Animal>(_animals);
            // And then, You can serialize 'Animals' with 'List<Animal>'.
            GenericSerializer.Serialize<List<Animal>>(coll, writer, _animalTypes);
            writer.WriteEndElement();
        }
        #endregion
        public static List<Type> GetAnimalTypes()
        {
            List<Type> types = new List<Type>();
            Assembly asm = typeof(Animals).Assembly;
            Type tAnimal = typeof(Animal);
            //Query our types. We could also load any other assemblies and
            //query them for any types that inherit from Animal
            foreach (Type currType in asm.GetTypes())
            {
                if (!currType.IsAbstract
                    && !currType.IsInterface
                    && tAnimal.IsAssignableFrom(currType))
                    types.Add(currType);
            }
            return types;
        }
    }
