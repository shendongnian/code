    public class Item<T> {
    
      private List<T> data;
    }
    
    public class ItemText : Item<String> { ... }
    
    public class ItemImage : Item<Image> { ... }
