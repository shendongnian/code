    public class User
    {
        public User(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["user"];
            name = (string) jUser["name"];
            teamname = (string) jUser["teamname"];
            email = (string) jUser["email"];
            players = jUser["players"].ToArray();
        }
        public string name { get; set; }
        public string teamname { get; set; }
        public string email { get; set; }
        public Array players { get; set; }
    }
    // Use
    private void Run()
    {
        string json = @"{""user"":{""name"":""asdf"",""teamname"":""b"",""email"":""c"",""players"":[""1"",""2""]}}";
        User user = new User(json);
        Console.WriteLine("Name : " + user.name);
        Console.WriteLine("Teamname : " + user.teamname);
        Console.WriteLine("Email : " + user.email);
        Console.WriteLine("Players:");
   
        foreach (var player in user.players)
            Console.WriteLine(player);
     }
