    [Serializable]
    public class MyClass
    {
        [field:NonSerializedAttribute()]
        public int Id
        {
            get;
            private set;
        }
    }
