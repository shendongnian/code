    private Parameter() { }
    public string Name { get; private set; }
    public string Value { get; private set; }
    public static Parameter.Descriptor GetDescriptorByName(string Name)
    {
        return Parameter.Descriptor.GetByName(Name);
    }
    public class Descriptor
    {
        private Descriptor() { // Initialize Parameters }
        public IList<Parameter> Parameters { get; private set; } // Set to ReadOnlyCollection
        public string Name { get; private set; }
        public static Descriptor GetByName(string Name) { // Magic here, caching, loading, parsing, etc. }
    }
}
