    public interface IConsumer
    {
        XEntity Consume(Stream stream, out List<Error> errors);
    }
    public class XConsumer : IConsumer
    {
        public XEntity Consume(Stream stream, out List<Error> errors);
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
    ConsumerFactory.Create("x").Consume(document, out errors);
