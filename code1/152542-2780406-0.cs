    public class MyMembershipProvider : MembershipProvider
    {        
    
            public override bool ValidateUser(string username, string password)
            {    
                var oUserProvider = new MyUserProvider();  
                return oUserProvider.ValidateUser(username,password,CurrentTerritoryID);
            }
    }
