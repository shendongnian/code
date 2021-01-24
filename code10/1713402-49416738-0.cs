    public interface IConsumer
    { 
        bool TryConsume(Product product);
    }
    public class ConcreteConsumerA : IConsumer
    {
        public bool TryConsume(Product product)
        {
            if (product is SpecificProductA a)
            { 
                //consume a
                return true;
            }
            return false;
        }
    }
