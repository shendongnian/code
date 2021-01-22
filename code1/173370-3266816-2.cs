    class Ref<T>
    {
        public T Value { get; set; }
    }
    ... M same as before ...
    Ref<int> x = new Ref<int>();
    x.Value = 0;
    M(x); 
