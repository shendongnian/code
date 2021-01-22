    public class MyList<LinkedItem> : List<LinkedItem> 
                                          where LinkedItem : MyItem, new()
    {
        public int CallStaticMethod()
        {
            // Getting a static method named "M" from runtime type of LinkedItem 
            var methodInfo = typeof(LinkedItem)
                          .GetMethod("M", BindingFlags.Static | BindingFlags.Public);
            // Invoking the static method, if the actual method will expect arguments
            // they'll be passed in the array instead of empty array
            return (int) methodInfo.Invoke(null, new object[0]);
        }
    
    }
    
    public class MyItem
    {
    }
    
    class MyItemImpl : MyItem
    {
        public MyItemImpl()
        {
        }
    
        public static int M()
        {
            return 100;
        }
    }
