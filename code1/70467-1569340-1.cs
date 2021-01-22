    public class MockDispatcher : IDispatcher
    {
        public void Dispatch(Delegate method, params object[] args)
        { method.DynamicInvoke(args); }
    }
