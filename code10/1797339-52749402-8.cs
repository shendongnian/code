    public class DocumentViewModel
    {
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public ICollection<MetaViewModel> Metas { get; set; } = new List<MetaViewModel>();
        [NotMapped]
        public string Author // This could be update to be a Meta, or specialized view model.
        {
            get { return Metas.SingleOrDefault(x => x.Name == "Author")?.Value; }
        }
    }
    
    public class MetaViewModel
    {
        public int MetaId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
