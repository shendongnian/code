    public class TestApiController : UmbracoApiController
    {
        public int GetTest()
        {
            var ms = Services.MemberService;
            return ms.Count();
        }
    }
