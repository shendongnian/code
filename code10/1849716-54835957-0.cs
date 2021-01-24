    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PrimaryContactId { get; set; }
    
        [ForeignKey(nameof(PrimaryContactId))]
        public virtual CompanyContact PrimaryContact { get; set; }
    }
