    public static class MyExtensions
    {
       public static ItemBaseClass CreateNewItem(this BaseClass item)
       {
          return item.GetType().InvokeMember("MethodName", System.Reflection.BindingFlags.InvokeMethod, null, obj, null /* args */);
       }
    }
