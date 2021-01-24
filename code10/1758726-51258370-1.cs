    public sealed class Car
    {
        private readonly HashSet<Color> _colors;
        public Car(Id id, params Color[] colors)
        {
            Id = id;
            _colors = new HashSet<Color>(colors);
        }
        public Id Id { get; }
        public IReadOnlyCollection<Color> Colors => _colors;
    }
