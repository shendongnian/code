    [TestClass]
    public class OwinMiddlewareCookiesTest {
        [Test]
        public async Task MyMiddleware_Should_Set_RequestHeader_And_ResponseHeader() {
            //Arrange
            var cookieStore = new Dictionary<string, string> { { "cookie-name", "cookie-value" } };
            var cookies = new RequestCookieCollection(cookieStore);
            var request = Mock.Of<IOwinRequest>();
            var requestMock = Mock.Get(request);
            requestMock.Setup(_ => _.Cookies).Returns(cookies);
            requestMock.Setup(_ => _.User.Identity.IsAuthenticated).Returns(true);
            requestMock.Setup(_ => _.Headers.Append(It.IsAny<string>(), It.IsAny<string>()));
            var response = new OwinResponse();
            var context = Mock.Of<OwinContext>();
            var contextMock = Mock.Get(context);
            contextMock.CallBase = true;
            contextMock.Setup(_ => _.Request).Returns(request);
            contextMock.Setup(_ => _.Response).Returns(response);
            RequestDelegate next = _ => Task.FromResult((object)null);
            var myMiddleware = new MyMiddleware(next);
            //Act
            await myMiddleware.Invoke(context);
            //Assert
            requestMock.Verify(_ => _.Headers.Append("header-name", "header-value"));
            response.Headers.ContainsKey("Set-Cookie");
        }
    }
