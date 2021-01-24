    abstract class BaseClassB : BaseClass
    {
        public object B {get;set;}
        protected override void SomeMethod()
        {
            base.SomeMethod();
            if (B != null)        
            {
                //Do thing with B
                //
            }
        }
    }
