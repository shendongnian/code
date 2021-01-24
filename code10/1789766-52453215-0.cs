    public class Handler1 : IHandler
    {
        public void HandlerType()
        {
            Console.WriteLine("Handler1");
       }
    }
    
    public class Handler2 : IHandler
        {
            public void HandlerType()
            {
                Console.WriteLine("Handler2");
            }
        }
    
    public interface IHandler
        {
            void HandlerType();
        }
