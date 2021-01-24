    public class OrdeListViewModel
    {
        public Guid OrderId { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid? AcceptedByUserId { get; set; }
        public string Registration { get; set; }
        public string Description { get; set; }
        public User CreatedByUser { get; set; }
        public User AcceptedByUser { get; set; }
    }
