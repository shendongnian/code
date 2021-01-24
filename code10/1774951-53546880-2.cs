    public interface IA { }
    public class AImp : IA { }
    
    public interface IConsumer
    {
    }
    
    public interface IConsumer<T> : IConsumer
        where T : IA
    {
        void Consume(T val);
    }
    
    public class Consumer : IConsumer<AImp>
    {
        public void Consume(AImp val)
        {
            // do smth
        }
    }
    
    public class Program
    {
        public static void Main()
        {
            IList<IConsumer> l1 = new List<IConsumer>();
            l1.Add(new Consumer());  // ok
        }
    }
