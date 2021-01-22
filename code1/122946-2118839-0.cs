    class ImmutableStack<T>
    {
        private static readonly ImmutableStack<T> emptystack = whatever;
        public static ImmutableStack<T> Empty { get { return emptystack; } }
        ...
