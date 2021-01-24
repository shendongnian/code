    interface IB<T> where T:IA
    {
         T PropertyA { get; set; }
    }
    class B : IB<A>
    {
        public A PropertyA { get; set; }
    }
