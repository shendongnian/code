    public interface IChild<T> {
        T Parent { get;  set; }
    }
    public interface IParent<T> {
        List<T> Children { get; set; }
    }
    public abstract class BaseItem<T1, T2> : IParent<T1>, IChild<T2>
    {
        public List<T1> Children { get; set; }
        public T2 Parent { get; set; }
    }
    public class ItemA : IParent<ItemB>
    {
        public List<ItemB> Children { get;  set; }
    }
    public class ItemB : BaseItem<ItemC, ItemA>
    {
    }
    public class ItemC : BaseItem<ItemD, ItemB>
    {
    }
    public class ItemD : IChild<ItemC>
    {
        public ItemC Parent { get;  set; }
    }
