    public delegate void MyCustomEventHandler(object sender, MyCustomEventArgs e);
    public class MyCustomEventClass 
    {
        public event MyCustomEventHandler MyCustomEvent;
    }
