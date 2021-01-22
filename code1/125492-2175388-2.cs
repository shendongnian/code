    [AttributeUsage(AttributeTargets.Class)]
    public class SerializeLinqEntities : Attribute
    {
    }
    
    public class LinqEntitiesSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(
          object obj, SerializationInfo info, StreamingContext context)
        {
            EntitySerializer.Serialize(this, obj.GetType(), info, context);
        }
    
        public object SetObjectData(
          object obj, SerializationInfo info,
          StreamingContext context, ISurrogateSelector selector)
        {
            EntitySerializer.Deserialize(obj, obj.GetType(), info, context);
            return obj;
        }
    }
    
    
    /// <summary>
    /// Returns LinqEntitySurrogate for all types marked SerializeLinqEntities
    /// </summary>
    public class NonSerializableSurrogateSelector : ISurrogateSelector
    {
        public void ChainSelector(ISurrogateSelector selector)
        {
            throw new NotImplementedException();
        }
    
        public ISurrogateSelector GetNextSelector()
        {
            throw new NotImplementedException();
        }
    
        public ISerializationSurrogate GetSurrogate(
          Type type, StreamingContext context, out ISurrogateSelector selector)
        {
            if (!type.IsDefined(typeof(SerializeLinqEntities), false))
            {
                //type not marked SerializeLinqEntities
                selector = null;
                return null;
            }
            selector = this;
            return new LinqEntitiesSurrogate();
        }
    
    }
    
    [SerializeLinqEntities]
    public class TestSurrogate
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    class Program
    {
        static void Main(string[] str)
        {
    
            var ns1 = new TestSurrogate {Id = 47, Name = "TestName"};
            var formatter = new BinaryFormatter();
            formatter.SurrogateSelector = new NonSerializableSurrogateSelector();
    
            using (var ms = new MemoryStream())
            {
                formatter.Serialize(ms, ns1);
                ms.Position = 0;
    
                var ns2 = (TestSurrogate) formatter.Deserialize(ms);
                // Check serialization
                Debug.Assert(ns1.Id == ns2.Id);
                Debug.Assert(ns1.Name == ns2.Name);
            }
        }
    }
