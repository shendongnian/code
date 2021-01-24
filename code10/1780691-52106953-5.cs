    public class DiseaseGroup
    {
        public string Name { get; set; }
        public List<Disease> Diseases;
        public DiseaseGroup(string name, Disease[] diseases)
        {
            Name = name;
            Diseases = new List<Disease>(diseases);
        }
    }
