    public static class MyExtensions
    {
       public static BaseClass CreateNewItem(this BaseClass item)
       {
          if (item is SubClassA)
          {
             return ((SubClassA)item).CreateNewItem();
          }
          
          // more code here for other scenarios...
       }
    }
