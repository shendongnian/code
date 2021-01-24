    public class DummyHolder : IReturnVoid
    {
        public GadgetDto GadgetDto { get; set; }
        //...
    }
    public class DummyService : Service
    {
        public void Any(DummyHolder request){}
    }
