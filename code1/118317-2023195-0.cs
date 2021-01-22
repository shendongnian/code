    public struct Tuple<TItem1, TItem2, TItem3>
    {
        public Tuple(TItem1 item1, TItem2 item2, TItem3 item3)
        {
            this = new Tuple<TItem1, TItem2, TItem3>();
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
        public static bool operator !=(Tuple<TItem1, TItem2, TItem3> left, Tuple<TItem1, TItem2, TItem3> right)
        { return left.Equals(right); }
        public static bool operator ==(Tuple<TItem1, TItem2, TItem3> left, Tuple<TItem1, TItem2, TItem3> right)
        { return !left.Equals(right); }
        public TItem1 Item1 { get; private set; }
        public TItem2 Item2 { get; private set; }
        public TItem3 Item3 { get; private set; }
        public override bool Equals(object obj)
        {
            if (obj is Tuple<TItem1, TItem2, TItem3>)
            {
                var other = (Tuple<TItem1, TItem2, TItem3>)obj;
                return Object.Equals(Item1, other.Item1)
                    && Object.Equals(Item2, other.Item2)
                    && Object.Equals(Item3, other.Item3);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ((this.Item1 != null) ? this.Item1.GetHashCode() : 0)
                 ^ ((this.Item2 != null) ? this.Item2.GetHashCode() : 0)
                 ^ ((this.Item3 != null) ? this.Item3.GetHashCode() : 0);
        }
    }
