    public interface IObjectBuilder
    {
        object GetCreateObjectWithData(string classPlusId);
    }
		
    public class ObjectABuilder : IObjectBuilder
    {
        public object GetCreateObjectWithData(string classPlusId)
        {
            ObjectA loadedObject;
            ObjectFactory.TryGetObject(classPlusId, out loadedObject);
            loadedObject.SomeProperty = "someValue"; // etc
            return loadedObject;
        }
    }
