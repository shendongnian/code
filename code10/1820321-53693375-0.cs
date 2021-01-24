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
    // testcode
    var mockFactory = new Mock<IProductFactory>();
    mockFactory.Setup( x => x.CreateProduct() ).Returns( () => 
    {
        var mockProduct = new Mock<IProduct>();
        // TODO setup product mock here
        return mockProduct.Object;
    } );
    var instance = new SubjectUnderTest( mockFactory.Object );
    instance.DoStuff(); // <- uses the factory mock defined above to create a mocked product and calls into the mocked product
