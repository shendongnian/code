    interface IFoo<out T>
    {
        T Bar { get; }
    }
    interface IBar<in T>
    {
        void Add(T value);
    }
    delegate void ContravariantAction<in T>(T value);
    delegate T CovariantFunc<out T>();
