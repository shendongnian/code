    public abstract class RootItem<T2> : AbstractBase
        where T2 : AbstractBase
    {
        public List<T2> Children = new List<T2>();
    }
    
    public abstract class LeafItem<T1> : AbstractBase
        where T1 : AbstractBase
    {
        public T1 Parent { get; protected set; }
    }
    public class ItemA : RootItem<ItemB>
    {
    }
    public class ItemB : BaseItem<ItemA, ItemC>
    {
    }
    public class ItemC : BaseItem<ItemB, ItemD>
    {
    }
    public class ItemD : LeafItem<ItemC>
    {
    }
