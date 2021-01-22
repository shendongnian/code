    public class CommonEventHandler
    {
        private CommonEventHandler() { }
    
        private object Context { get; set; }
    
        public static EventHandler CreateShowHandlerFor(object context)
        {
            CommonEventHandler handler = new CommonEventHandler();
    
            handler.Context = context;
    
            return new EventHandler(handler.HandleGenericShow);
        }
    
        private void HandleGenericShow(object sender, EventArgs e)
        {
            Console.WriteLine(this.Context);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            EventHandler show5 = CommonEventHandler.CreateShowHandlerFor(5);
            EventHandler show7 = CommonEventHandler.CreateShowHandlerFor(7);
    
            show5(null, EventArgs.Empty);
            Console.WriteLine("===");
            show7(null, EventArgs.Empty);
        }
    }
