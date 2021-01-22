    using System.Web.Security;
    public class MyCustomMembershipProvider : MembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            if (username.Equals("BenAlabaster") && password.Equals("Elephant"))
                return true;
            return false;
        }
        /* Override all the other methods required to extend MembershipProvider */        
    }
