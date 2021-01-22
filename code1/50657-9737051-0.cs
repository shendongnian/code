    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Security;
    class UserRoles
    {
  
        static void Main(string[] args)
        {
        MembershipCreateStatus result;
        Membership.CreateUser("testuser", "Pass!", "test@test.com", "Hood", "Pine Hills", true, out result);
        Console.WriteLine(result.ToString());
        Roles.CreateRole("Developer");
        Roles.AddUserToRole("testuser", "Developer");
       if (Roles.IsUserInRole("testuser","developer")) 
           Console.WriteLine("Is a developer");
       else
           Console.WriteLine("Doesn't write code.");
        
        if (Membership.ValidateUser("testuser", "Pass!")) 
           Console.WriteLine("User Validated.");
       else
           Console.WriteLine("User Invalid");
       Console.ReadKey();
        }
    }
