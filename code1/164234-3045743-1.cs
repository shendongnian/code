        interface IFoo
        {
            IFoo Bar();
        }
    
    class Foo : IFoo
        {
    
            #region IFoo Members
    
            public IFoo Bar()
            {
                return new Foo();
            }
    
            #endregion
        }
