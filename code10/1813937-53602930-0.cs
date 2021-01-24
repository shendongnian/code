    public class Parent
    {
    [BsonSerializer(typeof(ImpliedImplementationInterfaceSerializer<IEnumerable<IChild>, IEnumerable<Child>>))]
        public IEnumerable<IChild> Children { get; set; }
    }
