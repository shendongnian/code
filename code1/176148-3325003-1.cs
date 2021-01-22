    class MyEventArgs : EventArgs
    {
       public bool ReturnValue {get; set; }
       // and something more here.
    }
    public class A
    {
       public event EventHandler<MyEventArgs> MyEvent;
    }
