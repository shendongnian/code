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
                dynamic jsonObject = serializer.Deserialize<dynamic>(json);
                dynamic x = jsonObject["user"]; // result is Dictionary<string,object> user with fields name, teamname, email and players with their values
                x = jsonObject["user"]["name"]; // result is asdf
                x = jsonObject["user"]["players"]; // result is object[] players with its values
            }
        }
    }
