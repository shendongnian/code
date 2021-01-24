    public class DerivedBSerialize : BaseSerialize, IDerivedB
    {
        public string Name { get; set; }
        public IEnumerable<DerivedASerialize> DerivedBs { get; set; }
        string IDerivedB.Name { get; set; }
        IEnumerable<IDerivedA> IDerivedB.DerivedBs { get; set; }
    }
