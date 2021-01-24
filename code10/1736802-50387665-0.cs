    [Subject("Authentication")]
    public class When_authenticating_a_user
    {
        Establish context = () =>
        {
            Subject = new SecurityService();
        };
        Cleanup after = () =>
        {
            Subject.Dispose();
        };
        static SecurityService Subject;
    }
