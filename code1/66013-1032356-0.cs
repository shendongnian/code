    [Guid("7366fe1c-d84f-4241-b27d-8b1b6072af92")]
    public interface IStringCollection
    {
        int Count { get; }
        string Get(int index);
    }
    
    [Guid("8e8df55f-a90c-4a07-bee5-575104105e1d")]
    public interface IMyThing
    {
        IStringCollection GetListOfStrings();
    }
    public class StringCollection : List<string>, IStringCollection
    {
        public string Get(int index)
        {
            return this[index];
        }
    }
    public class Class1 : IMyThing
    {
        public IStringCollection GetListOfStrings()
        {
            return new StringCollection { "Hello", "World" };
        }
    }
