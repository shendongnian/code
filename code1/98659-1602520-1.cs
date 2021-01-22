    [Serializable]
    public class MyClass
    {        
        public string field1;
        [NonSerialized]
        public string field2;
        [OptionalField]
        public string field3;
    }
