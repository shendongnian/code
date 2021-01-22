    public class MutablePair<TFirst, TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }
        public MutablePair()
        {
        }
        public MutablePair(TFirst first, TSecond second)
        {
            First = first;
            Second = second;
        }
    }
