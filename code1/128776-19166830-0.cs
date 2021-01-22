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
                var json = "{\"test1\":\"1\",\"test2\":\"2\",\"test3\":{\"apple\":\"1\",\"orange\":\"2\",\"grape\":\"3\"}}";
                var dynamicObject = Json.Decode(json);
    
                dynamic x = dynamicObject.test1; // result = 1
                x = dynamicObject.test2; // result = 2
                x = dynamicObject.test3; // result is dynamic json object test3 with fields apple, orange and grape with their values
            }
        }
    }
