    public static class MyDbFunctions
    {
    	[DbFunction("JSON_VALUE", "")]
    	public static string JsonValue(string source, string path) => throw new NotSupportedException();
    }
