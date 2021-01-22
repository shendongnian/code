    public static class Require
    {
    
        public static IStringAssertion ThatString(string value)
        {
            return null;
        }
    
        public static IAssertion<T> That<T>(T value)
        {
            return null;
        }
    
    }
    
    public class RAR
    {
        public void TestMethod(StringComparer a, string b)
        {
            Require.That<StringComparer>(a).IsNotNull();
            Require.ThatString(b).IsNotNullOrEmpty();
        }
    }
