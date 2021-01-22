    [Serializable]
    public class MyFancyClass
    { ... }
    // Somewhere Else:
    public void function()
    {
       Type t = typeof(MyFancyClass);
       var attributes = t.GetCustomAttributes(true);
       if (attributes.Count(p => p is SerializableAttribute) > 0)
       {
           // This class is serializable, let's do something with it!
       }     
    }
