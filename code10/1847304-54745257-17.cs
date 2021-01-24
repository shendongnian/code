    public class LightDistributor
    {
        public string Description { get; set; }
        // ...
        public List<Field> Hardware { get; } = new List<Field>();
        public List<Type> Inputs { get; } = new List<Type>();
        public List<Type> Outputs { get; } = new List<Type>();
        public List<NamedSection> Sections { get; }
        public LightDistributor()
        {
            this.Sections = new List<NamedSection>()
            {
                new NamedSection() { Name = "Hardware", Items = this.Hardware },
                new NamedSection() { Name = "Inputs", Items = this.Inputs },
                new NamedSection() { Name = "Outputs", Items = this.Outputs },
            };
        }
    }
