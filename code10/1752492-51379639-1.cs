    [DataContract]
    public class ClassB : ClassA
    {
        static ClassB()
        {
            ClassA.DerivedTypes.Add(typeof(ClassB));
        }
        public ClassB()
        {
        }
    }
 
