    using System;
    using System.Security.Principal;
    using Moq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var mockIdentity = new Mock<IIdentity>();
                var mockPrincipal = new Mock<IPrincipal>();
    
                mockIdentity.SetupGet(x => x.Name).Returns("Robert");
                mockPrincipal.SetupGet(x => x.Identity).Returns(mockIdentity.Object);
    
                IPrincipal myStub = mockPrincipal.Object;
    
                Console.WriteLine(myStub.Identity.Name);
            }
        }
    }
