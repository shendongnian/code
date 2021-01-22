    public class MyOtherClient : ClientBase<IMyContract>, IMyContract
    {
        public void Method()
        {
            Channel.Method();
        }
    }
