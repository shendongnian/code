    public abstract class ContextSpecification
    {
        [FixtureSetUp]
        public void SetUp()
        {
            EstablishContext();
            Act();
        }
    
        protected abstract void Act();
    
        protected abstract void EstablishContext();
    
        [FixtureTearDown]
        public void TidyUpCore()
        {
            TidyUp();
        }
        
        protected virtual void TidyUp()
        {
            
        }
    }
