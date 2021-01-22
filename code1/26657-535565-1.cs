    public struct TempTuple<TFirst, TSecond>
    {
        public TempTuple(TFirst first, TSecond second)
        {
            this = new TempTuple<TFirst, TSecond>(); // Kung fu!
            this.First = first;
            this.Second = second;
        }
        public TFirst First { get; private set; }
        public TSecond Second { get; private set; }
