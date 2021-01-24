        public class Company
        {
            [Key]
            public int Id { get; set; }
            public virtual ICollection<CompanyJournals> CompanyJournals { get; set; }
        }
        public class Journal
        {
            [Key]
            public int Id { get; set; }
            public virtual ICollection<CompanyJournals> CompanyJournals { get; set; }
        }
        public class CompanyJournals
        {
            [Key]
            public int Id { get; set; }
            public int CompanyId { get; set; }
            public int JournalId { get; set; }
            [ForeignKey("CompanyId")]
            public virtual Company Company { get; set; }
            [ForeignKey("JournalId")]
            public virtual Journal Journal { get; set; }
        }
