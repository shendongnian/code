    namespace Newtonsoft.Json.Linq
    {
    	public static class JsonExtensions
    	{
    		public static void Add(this JObject target, string propertyName, object value) =>
    			target.Add(propertyName, JToken.FromObject(value));
    	}
    }
