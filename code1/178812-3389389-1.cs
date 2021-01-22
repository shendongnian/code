    public interface IChildOf<T> {
        T Parent { get;  set; }
    }
    public interface IParent<T> {
        List<T> Children { get; set; }
    }
    //This class handles all of the cases that have both parent and children
    public abstract class BaseItem<T1, T2> : IParent<T1>, IChildOf<T2>
    {
        public List<T1> Children { get; set; }
        public T2 Parent { get; set; }
    }
    //This class handles the top level parent
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
    //.... as many intermediates as you like.
    //This class handles the bottom level items with no children
    public class ItemD : IChildOf<ItemC>
    {
        public ItemC Parent { get;  set; }
    }
