    abstract class ThingDoerBase : IDoStuff
    {
        private Func<IRequest> _factory;
    
        protected ThingDoerBase(Func<IRequest> factory) => _factory = factory;
    
        // simplifed but default for the integer parm
        public virtual string DoThingOne<T>(T parm) => DoThingOne(parm, 25); 
        public virtual string DoThingOne<T>(T parm, int anotherParm)
        {
            if(!(_factory() is IRequest<T> request))
                throw new InvalidOperationException();
    
            request.GenericParm = parm;
            request.IntParm = anotherParm;
            return SendRequest(request);
        }
        public abstract string SendRequest<T>(IRequest<T> request);
    
        public void ChangeRequestFactory(Func<IRequest> factory) => _factory = factory;
    }
