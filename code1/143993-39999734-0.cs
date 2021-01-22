    public class Catalog
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public Catalog Parent { get; set; }
        public ICollection<Catalog> ChildCatalogs { get; set; }
    }
