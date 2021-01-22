        public class MyBase
        {
            public virtual void DoMe()
            {
        
            }
        }
        
        public class MyDerived:MyBase
        {
    //note the use of 'new' and not 'override'
            public new void DoMe()
            {
                throw  new NotImplementedException();
            }
        }
