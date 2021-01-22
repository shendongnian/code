     public class user
    {
        public string username { get; set; }
        public string password { get; set; }
    }
      List<user> userlist = new List<user>();
            userlist.Add(new user { username = "macbruno", password = "1234" });
            userlist.Add(new user { username = "james", password = "5678" });
            string myusername = "james";
            string mypassword = "23432";
      user theUser = userlist.Find(
                delegate (user thisuser)
                {
                    return thisuser.username== myusername && thisuser.password == mypassword;
                }
                );
                if (theUser != null)
                {
                   Dosomething();
                }
                else
                {
                    DoSomethingElse();
                   
                }
