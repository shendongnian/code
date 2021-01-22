    public class ClassA : ISerializable
    {
        private ClassB _dependency;
        public ClassA(SerializationInfo information, StreamingContext context)
        {
            _dependency 
                = (ClassB)information.GetValue("_dependency", typeof(ClassB));
            
            // TODO: Get other values from the serialization info.
            // TODO: Set up stuff from dependent object.
        }
        public SerializationInfo GetObjectData()
        {
            information.AddValue("_dependency", _dependency, typeof(ClassB));
            // TODO: Add other fields to the serialization info.
        }
    }
