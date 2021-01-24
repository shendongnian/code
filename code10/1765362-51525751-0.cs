    public class TermoUso : BaseEntity
    {
        public Guid TermoUsoKeyId { get; set; }
        public virtual TermoUsoKey TermoUsoKey { get; set; }
        [Required]
        [StringLength(8000)]
        public string Texto { get; set; }
    }
