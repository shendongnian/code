    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Script.Serialization;
    
    namespace Tests
    {
        [TestClass]
        public class JsonTests
        {
            [TestMethod]
            public void Test()
            {
                var json = "{\"user\":{\"name\":\"asdf\",\"teamname\":\"b\",\"email\":\"c\",\"players\":[\"1\",\"2\"]}}";
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var sessionObject = serializer.Deserialize<dynamic>(json);
                var x = sessionObject["user"]; // result is dynamic json object user with fields name, teamname, email and players with their values
                x = sessionObject["user"]["name"]; // result is asdf
                x = sessionObject["user"]["players"]; // result is dynamic json array players with its values
            }
        }
    }
