    [TextFixture]
    public class CustomerTestFixture
    {
       var customer = new Customer();
       var accessor = new Customer_Accessor( new PrivateObject( customer ) );
       Assert.IsTrue( accessor.CanTestPrivateMethod() );
    }
