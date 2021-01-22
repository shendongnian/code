    public class PersonConfig : ExtendedXmlSerializerConfig<Person>
    {
        public PersonConfig()
        {
            ObjectReference(p => p.Id);
        }
    }
