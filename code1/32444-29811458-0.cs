        public class HandlerFactory: Handler
        {
            public IHandler GetHandler()
            {
                return base.CreateMe();
            }
        }
        public interface IHandler
        {
            void DoWork();
        }
        public class Handler : IHandler
        {
            public void DoWork()
            {
                Console.WriteLine("hander doing work");
            }
            protected IHandler CreateMe()
            {
                return new Handler();
            }
            protected Handler(){}
        }
        public static void Main(string[] args)
        {
            // Handler handler = new Handler();         - this will error out!
            var factory = new HandlerFactory();
            var handler = factory.GetHandler();
            
            handler.DoWork();           // this works!
        }
