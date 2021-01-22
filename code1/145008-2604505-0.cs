    public interface IFoo<T>
      where T:Bar_base
    {
        void Process(T bar);
    }
