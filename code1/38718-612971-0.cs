    public delegate double CustomerDelegate(int test);
    public interface ITest
    {
        EventHandler<EventArgs> MyHandler{get;set;}
        CustomerDelegate HandlerWithCustomDelegate { get; set; }
        event EventHandler<EventArgs> MyEvent;
    }
