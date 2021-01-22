    public static class Tuple
    {
     
        public static Tuple<T1, T2> Create<T1, T2>(T1 item1, T2 item2)
        {
            return new Tuple<T1, T2>(item1, item2);
        }
        public static Tuple<T1, T2, T3> Create<T1, T2, T3>(T1 item1, T2 item2, T3 item3)
        {
            return new Tuple<T1, T2, T3>(item1, item2, item3);
        }
    }
    public class Tuple<T1, T2>
    {
        
        public Tuple(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
        
        public T1 Item1 { get; set;}
        public T2 Item2 { get; set;}
        public override string ToString()
        {
            return string.Format("Item1: {0}, Item2: {1}", Item1, Item2);
        }
    }
    public class Tuple<T1, T2, T3> : Tuple<T1, T2>
    {
        public T3 Item3 { get; set; }
        public Tuple(T1 item1, T2 item2, T3 item3) : base(item1, item2)
        {
            Item3 = item3;
        }
        public override string ToString()
        {
            return string.Format(base.ToString() + ", Item3: {0}", Item3);
        }
    }
