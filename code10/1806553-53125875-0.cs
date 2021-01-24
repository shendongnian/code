    [TestFixture]
    public class SecurityUserMgmtTests
    {
        
        protected override SecurityUserManagementPage Page {get;set;}
        
        [SetUp]
        public void Init() => Page = new LoginPage().LoginasAdmin().GoToSecurityUserMgmtPage();
        // Tests omitted
    }
