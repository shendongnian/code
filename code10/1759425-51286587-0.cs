    public class UsersRepository 
    {
        public List<User> Users;
    }
    
    public class User 
    {
        public int serialNo;
        public UserDetails details;
    }
    public class UserDetails
    {
         public string name;
         public string job;
    }
    using (var response = (HttpWebResponse)request.GetResponse())
    {
        using (var reader = new StreamReader(response.GetResponseStream()))
        {
            var json = reader.ReadToEnd();
            var usersList = JsonConvert.DeserializeObject<UsersRepository>(json);
            Console.WriteLine(usersList[0].details.name); // prints "John"
        }
    }
