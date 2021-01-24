    internal class SubjectUnderTest
    {
        public SubjectUnderTest( IProductFactory factory )
        {
            _factory = factory;
        }
        public void DoStuff()
        {
            var product = _factory.CreateProduct(); // this creates a mocked product (where you new'ed something before)
            product.DoSomeThing(); // this calls into the mock product
        }
        private readonly IProductFactory _factory;
    }
