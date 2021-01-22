    public sealed class Adapter
    {
        private static readonly Lazy<Adapter> instance = new Lazy<Adapter>(() => new Adapter());
        public static Adapter Instance { get { return instance.Value; } }
        private Adapter() { }
    }
