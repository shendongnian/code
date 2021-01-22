    class Program
    {
        static void Main(string[] args)
        {
            var item = new MyType();
            if( item is IMyType ){
              Console.WriteLine( (item as IMyType).SayHello() );
            }
    
         }
    }
