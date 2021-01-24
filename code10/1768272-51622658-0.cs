    public class ContextHelper
    {
        public static HttpContext GetMockedHttpContext()
        {
            var context = new Mock<HttpContext>();
            var identity = new Mock<IIdentity>();
            var contextUser = new Mock<ClaimsPrincipal>();
            contextUser.Setup(ctx => ctx.Identity).Returns(identity.Object);
            identity.Setup(id => id.IsAuthenticated).Returns(true);
            identity.Setup(id => id.Name).Returns("validemail@test.com");
            context.Setup(x => x.User).Returns(contextUser.Object);
            return context.Object;
        }
    }
