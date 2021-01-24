  public sealed class CustomLuisAttribute : LuisModelAttribute
    {
        public CustomLuisAttribute(string modelID, string subscriptionKey, LuisApiVersion apiVersion = LuisApiVersion.V2, string domain = null, double threshold = 0) 
            : base(modelID : ConfigurationManager.AppSettings["ModelId"], subscriptionKey : ConfigurationManager.AppSettings["LuisSubscriptionKey"])
        {
        }
    }
Use it as an attribute to your root dialog
[CustomLuisAttribute]
[Serializable]
public class RootDialog : LuisDialog<object>
{
}
