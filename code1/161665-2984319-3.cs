    [TestClass]
    public class CustomerServiceTests {
         CustomerServiceTester customerService;
         Mock<ICustomerRepository> customerRepositoryMock;
         [TestInitialize]
         public void Setup() {
              customerRepoMock = new Mock<ICustomerRepository>();
              customerService = new CustomerServiceTester(customerRepoMock.Object);
         }
         public class CustomerServiceTester : CustomerService {    
              public void MakePreferredTest(Customer customer) {
                  MakePreferred(customer);
              }
              // You could also add in test specific instrumentation
              // by overriding MakePreferred here like so...
              protected override void MakePreferred(Customer customer) {
                  CustomerArgument = customer;
                  WasCalled = true;
                  base.MakePreferred(customer);
              }
              public Customer CustomerArgument { get; set; }
              public bool WasCalled { get; set; }
         }
         [TestMethod]
         public void MakePreferred_WithValidCustomer_MakesCustomerPreferred() {
             Customer customer = new Customer();
             customerService.MakePreferredTest(customer);
             Assert.AreEqual(true, customer.IsPreferred);
         }
         // Rest of your tests
    }
