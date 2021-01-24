    public class RequestA : BasicRequest<DerivedClassA>
        {
            public override void Execute(DerivedClassA ibase)
            {
                // Do stuff with derived
            }
        }
    
        public class RequestB : BasicRequest<DerivedClassB>
        {
            public override void Execute(DerivedClassB ibase)
            {
                // Do stuff with derived
            }
        }
