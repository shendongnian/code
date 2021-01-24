     public static List<User> listuser = new List<User>(){
            new User() {ID = 1, UserName = "Dhruv", Password = "hello"},
            new User() {ID = 2, UserName = "Gaurav", Password = "12345"},
            new User() {ID = 3, UserName = "Rahul", Password = "asdfg"},
            new User() {ID = 4, UserName = "Guru", Password = "qwerty"}
        };
    protected bool UserExists(string userName, string password)
    {
       return listuser.Any(a => 
                  a.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase) 
                  && 
                  a.Password.Equals(password));
    }
