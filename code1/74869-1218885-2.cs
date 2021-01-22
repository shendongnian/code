    public class When_user_enters_valid_credentials : MembershipContext 
    {
        static ActionResult result;
        static string username;
        static string password;
        Establish context = () =>
        {
            username = "ValidUsername";
            password = "ValidPassword";
            // This is context-specific: Username/password is valid
            membership.Setup<bool>(
                m => m.Validate(Param.Is<string>(
                    s => s == username), Param.Is<string>(
                        s => s == password)
                    )
                ).Returns(true);
        };
        Because of = () =>
        {
            result = loginController.Login(username, password);
        };
    
        ThenIt should_log_the_user_in;
        ThenIt should_redirect_the_user_to_the_admin_panel;
        ThenIt should_show_message_confirming_successful_login;
    }
    
    public abstract class MembershipContext 
    {
        protected static Mock<ISiteMembership> membership;
        protected static LoginController loginController;
    
        Establish context = () =>
        {
            membership = new Mock<ISiteMembership>();
            loginController = new LoginController(membershipMock.Object);
        };
    }
