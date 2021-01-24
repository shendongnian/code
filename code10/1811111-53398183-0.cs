    public class TestApiController : UmbracoApiController
    {
        private static string _umbracoConnectionString = ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;
        private static IMemberService _memberService = global::Umbraco.Core.ApplicationContext.Current.Services.MemberService;
        
        public int GetTest()
        {
            var memberCount = _memberService.Count();
            return memberCount;
        }
    }
