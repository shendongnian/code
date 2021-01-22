    [DataContract]
    public class MyClass
    {
        public ChildObject(int i)
        {
        }
        [DataMember]
        public MyClass Parent
        {
            get;
            set;
        }
    }
