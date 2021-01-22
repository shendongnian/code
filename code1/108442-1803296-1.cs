    public class ItemGeneric<T> {
    
      private List<T> data;
    }
    
    public class ItemText : ItemGeneric<String> { ... }
    
    public class ItemImage : ItemGeneric<Image> { ... }
