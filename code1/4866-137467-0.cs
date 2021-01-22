    [TestFixture]
    public class LoginControllerTests : GenericBaseControllerTest<LoginController>
    {
        private string referrer = "http://www.example.org";
        protected override IMockRequest BuildRequest()
        {
            var request = new StubRequest(Cookies);
            request.UrlReferrer = referrer;
            return request;
        }
        protected override IMockResponse BuildResponse(UrlInfo info)
        {
            var response = new StubResponse(info,
                                            new DefaultUrlBuilder(),
                                            new StubServerUtility(),
                                            new RouteMatch(),
                                            referrer);
            return response;
        }
