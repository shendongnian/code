    public class Tuple<T, T2, T3>
    {
        public Tuple(T first, T2 second, T3 third)
            
        {
            First = first;
            Second = second;
            Third = third;
        }
        public T First { get; set; }
        public T2 Second { get; set; }
        public T3 Third { get; set; }
    }
