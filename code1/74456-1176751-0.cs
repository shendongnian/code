    public class Tuple<TItem1, TItem2> // other definitions for higher arity
    {
        public TItem1 Item1 { get; private set; }
        public TItem2 Item2 { get; private set; }
        public Tuple(TItem1 item1, TItem2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }
