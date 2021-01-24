    public class BookModel
    {
        public string Title { get; set; }
        public IEnumerable<AuthorModel> Authors { get; set; }
        public Category Category { get; set; }
        public string Isbn { get; set; }
        public string PublishingHouse { get; set; }
        public string Edition { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsLost { get; set; }
    }
    public class InventoryItemModel
    {
        public Guid BookId { get; set; }
        public BookModel Book { get; set; }
        public int Number { get; set; }
        public AcquisitionDetailModel AcquisitionDetail { get; set; }
    }
