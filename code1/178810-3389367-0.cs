    public abstract class AbstractBase
    {
        public abstract string Function1();
    }
    public class ItemA : AbstractBase
    {
        public List<ItemB> Children = new List<ItemB>();
    }
    public class ItemB : AbstractBase
    {
        public ItemA Parent { get; protected set; }
        public List<ItemC> Children = new List<ItemC>();
    }
    public class ItemC : AbstractBase
    {
        public ItemB Parent { get; protected set; }
        public List<ItemD> Children = new List<ItemD>();
    }
    public class ItemD : AbstractBase
    {
        public ItemC Parent { get; protected set; }
    }
