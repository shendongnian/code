    class ListDemo<T>:List<T>
    {
        public override T Add(T value)
        {
          return base.Add(value);
        }
    }
