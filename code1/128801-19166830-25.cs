    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Helpers;
    
    namespace Tests
    {
        [TestClass]
        public class JsonTests
        {
            [TestMethod]
            public void TestJsonDecode()
            {
                var json = "{\"user\":{\"name\":\"asdf\",\"teamname\":\"b\",\"email\":\"c\",\"players\":[\"1\",\"2\"]}}";
                dynamic jsonObject = Json.Decode(json);
                dynamic x = jsonObject.user; // result is dynamic json object user with fields name, teamname, email and players with their values
                x = jsonObject.user.name; // result is asdf
                x = jsonObject.user.players; // result is dynamic json array players with its values
            }
        }
    }
