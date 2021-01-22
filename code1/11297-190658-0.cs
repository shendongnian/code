    public class MemberTest
        {
            public static void CreateAdminMemberIfNotExists()
            {
                MembershipCreateStatus status;
                MembershipUser member = Membership.CreateUser("Admin", "password", "email@somewhere.co.uk", "Question", "Answer", true, out status);
            }
        }
