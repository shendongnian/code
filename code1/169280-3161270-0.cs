    private class StorageLibrary 
    {
    	private List<obj> storedObjects = new List<obj>();
        public void addObject(obj inspectionObject)
        {
            storedObjects.Add(inspectionObject);
            //And a lot more code
        }
    }
    
    public class Foo : StorageLibrary
    {
        //Declaration of libraries
        public static StorageLibrary storage1 = new StorageLibrary();
        public static StorageLibrary storage2 = new StorageLibrary();
        ...
        
    	private void ObjectFeed(/* PARAMATERS */)
    	{
            //generate objects
    
            if (objectType == Type.Type1)
            {
                storage1.addObject(inspectionObject);
            }
            if (objectType == Type.Type2)
            {
                storage2.addObject(inspectionObject);
            }
            ...
    	}
    }
