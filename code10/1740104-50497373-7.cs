    abstract class ThingDoerBase : IDoStuff
    {
        private Func<IRequest> _requestFactory;
    
        protected ThingDoerBase(Func<IRequest> requestFactory) => _requestFactory = requestFactory;
    
        public virtual string DoThingOne(string parm) => DoThingOne(parm, 25);
    
        public virtual string DoThingOne(string parm, int anotherParm)
        {
            var request = _requestFactory();
            request.IntParm = anotherParm;
            request.StringParm = parm;
            return SendRequest(request);
        }
        public abstract string SendRequest(IRequest request);
    
        public void ChangeFactory(Func<IRequest> requestFactory)
        {
            if (requestFactory != null)
                _requestFactory = requestFactory;
        }
    }
