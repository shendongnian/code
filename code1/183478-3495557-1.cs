    class MyItem : MyItem {
      static void TheFunction() { ... }
    }
    
    public class MyList<LinkedItem> : List<LinkedItem> where LinkedItem : MyItem, new()
    {
      public MyList(Action theStaticFunction) {
        ...
      }
    }
    
    new MyList<MyItem>(MyItem.TheFunction);
