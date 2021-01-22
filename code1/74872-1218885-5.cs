    // The "Subject" attribute is used as the "Scenario" in
    // in your original story, and gets rendered with your
    // MSpec report that is outputted (especially the HTML version).
    [Subject("Login Page")]
    public class When_user_enters_valid_credentials_for_existing_user 
        : MembershipContext 
    {
        static ActionResult result;
        static string username;
        static string password;
        // This is optional, but will inherit the MembershipContext, and 
        // allow for more specific setup of your context for these 
        // grouped specs only.
        Establish context = () =>
        {
            username = "ValidUsername";
            password = "ValidPassword";
            // This is context-specific: Username/password is valid
            membership.Setup<bool>(
                m => m.Validate(
                    Param.Is<string>(s => s == username)
                    ,Param.Is<string>(s => s == password)
                )
            ).Returns(true);
        };
        Because of = () =>
        {
            result = loginController.Login(username, password);
        };
    
        It should_log_the_user_in;
        It should_redirect_the_user_to_the_admin_panel;
        It should_show_message_confirming_successful_login;
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
