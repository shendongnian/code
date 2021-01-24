    using Google.Apis.Sample.MVC4;
    
    namespace Google.Apis.Sample.MVC4.Controllers
    {
        public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
        {
            protected override Google.Apis.Auth.OAuth2.Mvc.FlowMetadata FlowData
            {
                get { return new AppFlowMetadata(); }
            }
        }
    }
