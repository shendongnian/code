    [Subject("Login Page")]
    public class When_an_existing_user_enters_valid_credentials : MembershipContext 
    {
        Establish context = () =>
        {
            membership
                .Setup<bool>(m => m.Validate(
                    Param.Is<string>(s => s == username), 
                    Param.Is<string>(s => s == password)))
                .Returns(true);
        };
        Because of = () => result = loginController.Login(username, password);
    
        It should_log_the_user_in;
        It should_redirect_the_user_to_the_admin_panel;
        It should_show_message_confirming_successful_login;
        
        static ActionResult result;
        const string username = "username";
        const string password = "password";
    }
    
    public abstract class MembershipContext 
    {
        Establish context = () =>
        {
            membership = new Mock<ISiteMembership>();
            loginController = new LoginController(membership.Object);
        };
        
        protected static Mock<ISiteMembership> membership;
        protected static LoginController loginController;
    }
