    public MockLoginService : ILoginService
    {
       public bool Login(string username, string password)
       {
         return (username == "Name" && password == "Password");
       }
    }
