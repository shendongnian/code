    using Microsoft.Web.Services3.Design;
    // ...
    public class FooBarPolicy : Policy
    {
        public FooBarPolicy()
        {
            this.Assertions.Add(new UsernameOverTransportAssertion());
            this.Assertions.Add(new RequireSoapHeaderAssertion(
                "MyHeader","http://example.org/myheader"));  // needed?
        }
    }
