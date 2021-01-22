    public class JSONHelper
    {
    
    	public static string Serialize<T>(T obj)
    	{
    		System.Web.Script.Serialization.JavaScriptSerializer JSONserializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    		return JSONserializer.Serialize(obj);
    	}
    
    	public static T Deserialize<T>(string json)
    	{
    		T obj = Activator.CreateInstance<T>();
    		System.Web.Script.Serialization.JavaScriptSerializer JSONserializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    		obj = JSONserializer.Deserialize<T>(json);
    		return obj;
    	}
    
    }
