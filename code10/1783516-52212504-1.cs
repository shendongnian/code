    public class Controller
    {
        public Handler<Controller> Handler { get; }
        public Controller(Handler<Controller> handler)
        {
            Handler = handler;
        }
    }
