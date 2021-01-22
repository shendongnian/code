    public interface IEntry
    {
        string Description { get; set; }
    }
    public class Bug : IEntry
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
    }
    public class Incident : IEntry
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
    }
    public class Persister
    {
        public void Save(IEnumerable<IEntry> values)
        {
            foreach (IEntry value in values) { Save(value); }
        }
        public void Save(IEntry value)
        {
            if (value is Bug) { /* Bug save logic */ }
            else if (value is Incident) { /* Incident save logic */ }
        }
    }
