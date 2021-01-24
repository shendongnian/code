    class MyClient : ClientBase<IAllOfMyOps>, IAllOfMyOps
    {
        public MyClient(Binding binding, EndpointAddress endpoint) : base(binding, endpoint) { }
        public string OpA()
        {
            return base.Channel.OpA();
        }
        public string OpB()
        {
            return base.Channel.OpB();
        }
    }
