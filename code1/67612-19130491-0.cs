    public static class JSONHelper
    {
    	public static string ToJSON(this object obj)
    	{
    		JavaScriptSerializer serializer = new JavaScriptSerializer();
    		return serializer.Serialize(obj);
    	}
    }
