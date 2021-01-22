    class HoldObject<T>
    {
        public T Value { get; set; }
        public bool IsValueSet();
        public void WaitUntilHasValue();
    }
