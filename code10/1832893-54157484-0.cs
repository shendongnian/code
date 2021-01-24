    public class User
    {
       public string UserName { get; set; }
       public string FavoriteColor { get; set; }
    }
    public class Program
    {
    
       // A List to hold users
       private static List<User> _users = new List<User>();
    
       private static void Main(string[] args)
       {
          // lets add some people
          _users.Add(new User() { UserName = "Bob",FavoriteColor = "Red" });
          _users.Add(new User() { UserName = "Joe", FavoriteColor = "Green" });
          _users.Add(new User() { UserName = "Fred", FavoriteColor = "Blue" });
    
          // use a linq query to find someone
          var user = _users.FirstOrDefault(x => x.UserName == "Bob");
    
          // do they exist?
          if (user != null)
          {
             // omg yay, gimme teh color!
             Console.WriteLine(user.FavoriteColor);
          }
    
       }
    }
