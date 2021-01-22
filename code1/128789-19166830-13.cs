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
                var dynamicObject = Json.Decode(json);
                dynamic x = dynamicObject.user; // result is dynamic json object user with fields name, teamname, email and players with their values
                x = dynamicObject.user.name; // result is asdf
                x = dynamicObject.user.players; // result is dynamic json array players with its values
            }
        }
    }
