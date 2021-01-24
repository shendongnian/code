    public class Trackable<T>
    {
        public Trackable() { }
        public Trackable(T model) { Model = model; }
        public Guid Index { get; set; } = Guid.NewGuid();
        public bool Deleted { get; set; }
        public bool Added { get; set; }
        public T Model { get; set; }
    }
