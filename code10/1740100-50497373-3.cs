    class ThingDoer : ThingDoerBase
        {
            public override string DoThingOne(string parm, int anotherParm)
            {
                var req = new Imp1Request { StringParm = parm, IntParm = anotherParm
                };
                return SendRequest(req);
            }
            public override string SendRequest(IRequest req) => "XD";
    
            public ThingDoer(Func<IRequest> requestFactory) : base(requestFactory) { }
        }
