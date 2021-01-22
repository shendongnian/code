    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Script.Serialization;
    using System.Linq;
    
    namespace Tests
    {
        [TestClass]
        public class JsonTests
        {
            [TestMethod]
            public void TestJavaScriptSerializer()
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
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var jsonObject = serializer.Deserialize<dynamic>(json);
                name = (string)jsonObject["user"]["name"];
                teamname = (string)jsonObject["user"]["teamname"];
                email = (string)jsonObject["user"]["email"];
                players = jsonObject["user"]["players"];
            }
    
            public string name { get; set; }
            public string teamname { get; set; }
            public string email { get; set; }
            public Array players { get; set; }
        }
    }
