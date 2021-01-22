    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Helpers;
    using System.Linq;
    
    namespace Tests
    {
        [TestClass]
        public class JsonTests
        {
            [TestMethod]
            public void TestJsonDecode()
            {
                string json = "{\"user\":{\"name\":\"asdf\",\"teamname\":\"b\",\"email\":\"c\",\"players\":[\"1\",\"2\"]}}";
                User user = new User(json);
                Console.WriteLine("Name : " + user.name);
                Console.WriteLine("Teamname : " + user.teamname);
                Console.WriteLine("Email : " + user.email);
                Console.WriteLine("Players:");
                foreach (var player in user.players)
                    Console.WriteLine(player);
            }
        }
    
        public class User {
            public User(string json) {
                var jsonObject = Json.Decode(json);
                name = (string)jsonObject.user.name;
                teamname = (string)jsonObject.user.teamname;
                email = (string)jsonObject.user.email;
                players = ((DynamicJsonArray) jsonObject.user.players).ToArray();
            }
    
            public string name { get; set; }
            public string teamname { get; set; }
            public string email { get; set; }
            public Array players { get; set; }
        }
    }
