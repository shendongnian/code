    public class IndexedItem<TModel> {
      public IndexedItem(int index, TModel item) {
        Index = index;
        Item = item;
      }
    
      public int Index { get; private set; }
      public TModel Item { get; private set; }
    }
