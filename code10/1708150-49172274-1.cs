    // you don't necessarily need this interface but it allows a meaningful
    // constraint if you apply it to your 'entity' classes
    public interface IConsumed
    {
        // things it does
    }
    public class XEntity : IConsumed
    {
    }
    public class YEntity : IConsumed
    {
    }
    public interface IConsumer<T> where T : IConsumed
    {
        T Consume(Stream stream, out List<Error> errors);
    }
    public class XConsumer : IConsumer<XEntity>
    {
        public XEntity Consume(Stream stream, out List<Error> errors);
        {
            // something
        }
    }
    public class YConsumer : IConsumer<YEntity>
    {
        public YEntity Consume(Stream stream, out List<Error> errors);
        {
            // something
        }
    }
    
    public static class ConsumerFactory
    {
        public IConsumer Create(string someCriteria)
        {
            switch (someCriteria)
            {
                case "x":
                    return new XConsumer();
                case "y":
                    return new YConsumer();
            }
        }
    }
    XEntity x = ConsumerFactory.Create("x").Consume(document, out errors);
    YEntity y = ConsumerFactory.Create("y").Consume(document, out errors);
