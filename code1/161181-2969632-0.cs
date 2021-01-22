    public class TypeCollection : List<Type>
    {
        public TypeCollection()
        {
        }
    
        public new void Add(Type type)
        {
            Contract.Requires(type == typeof(string) || type == typeof(Stream));
            base.Add(type);
        }
    }
    
    public class TestCollection
    {
        public void Test()
        {
            TypeCollection collection = new TypeCollection();
            // This gets compile time warning:
            collection.Add(typeof(int));
        }
    }
