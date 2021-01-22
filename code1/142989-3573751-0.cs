    [ServiceBehavior]
    public class Webservice : IWebservice
    {
	    public IList<object> GetObjects()
	    {
	        return Database.Instance.GetObjects();
	    }
    }
