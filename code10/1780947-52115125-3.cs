    using Newtonsoft.Json;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            var json = 
            "{\"signInNames\":[{\"type\":\"emailAddress\",\"value\":\"user@example.com\"}]}";
            var user = JsonConvert.DeserializeObject<User>(json);
            System.Console.WriteLine(JsonConvert.SerializeObject(user)); 
        }
    }
    public abstract class UserB2C
    {
        public List<SignInName> SignInNames { get; set; }
    }
    public class User : UserB2C {  }
    public class SignInName
    {
        string Type { get; set; }
        string Value { get; set; }
    }
