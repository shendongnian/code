      public class Publisher<T>
        {
            public void Publish(T args)
            {
                Console.WriteLine("Hello");
            }
        }
        static void Main(string[] args)
        {
    
            var type = typeof(Publisher<>);
    
            Publisher<EventArgs> publisher = new Publisher<EventArgs>();
    
            var realizedType = type.MakeGenericType(typeof(EventArgs));
            realizedType.InvokeMember("Publish", BindingFlags.Default | BindingFlags.InvokeMethod,
            null,
            publisher
            ,
            new object[] { new EventArgs() });
    
        }
