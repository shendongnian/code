    using calledNS;
    ...
    namespace callerNS
    {
        public class CallerClass
        {
            public void CallerMethod() { CalledClass.CalledMethod(); }
        }
    }
