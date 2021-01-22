    public interface IEntry
    {
        string Description { get; set; }
        void Save(IPersister gateway);
    }
    public class Bug : IEntry
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public void Save(IPersister gateway)
        {
            gateway.SaveBug(this);
        }
    }
    public class Incident : IEntry
    {
        public Guid ID { get; set; }
        public string Description { get; set; }
        public void Save(IPersister gateway)
        {
            gateway.SaveIncident(this);
        }
    }
    public interface IPersister
    {
        void SaveBug(Bug value);
        void SaveIncident(Incident value);
    }
    public class Persister : IPersister
    {
        public void Save(IEnumerable<IEntry> values)
        {
            foreach (IEntry value in values) { Save(value); }
        }
        public void Save(IEntry value)
        {
            value.Save(this);
        }
        public void SaveBug(Bug value)
        {
            // Bug save logic
        }
        public void SaveIncident(Incident value)
        {
            // Incident save logic
        }
    }
