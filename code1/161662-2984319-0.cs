    public class CustomerServiceMock : CustomerService {
        public void DoSomethingTester() {
             // Set up state or whatever you need
             DoSomething();
        }
    }
    [TestMethod]
    public void DoSomething_WhenCalled_DoesSomething() {
        CustomerServiceMock serviceMock = new CustomerServiceMock(...);
        serviceMock.DoSomethingTester();
     }
