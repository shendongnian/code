    abstract class OuterBase<TInnerItem>
    {
    }
    class Outer<TInner, TInnerItem> : OuterBase<TInnerItem> where TInner : Inner<TInnerItem>
    {
        public void Add(TInner item)
        {
            item.Outer = this; // Compiles
        }
    }
    class Inner<TInnerItem> : ICollection<TInnerItem>
    {
        OuterBase<TInnerItem> _outer;
        public OuterBase<TInnerItem> Outer
        {
            set { _outer = value; }
        }
    }
