    using Microsoft.Web.Services3.Design;
    // ...
    public class FooBarPolicy : Policy
    {
        public FooBarPolicy()
        {
            this.Assertions.Add(new UsernameOverTransportAssertion());
        }
    }
