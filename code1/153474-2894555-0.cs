    public class Assert2
    {
        public static void IsSameValue(object expectedValue, object actualValue) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var expectedJSON = serializer.Serialize(expectedValue);
            var actualJSON = serializer.Serialize(actualValue);
            Assert.AreEqual(expectedJSON, actualJSON);
        }
    }
    public static class It2
    {
        public static T IsSameSerialized<T>(T expectedRecord) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string expectedJSON = serializer.Serialize(expectedRecord);
            return Match<T>.Create(delegate(T actual) {
                string actualJSON = serializer.Serialize(actual);
                return expectedJSON == actualJSON;
            });
        }
    }
