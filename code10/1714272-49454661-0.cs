    [Table("Artikel")]
    public class Artikel
    {
        [Key]
        [Column(Order = 1)]
        public string Artnr { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ArtVersie { get; set; }
        public string ArtOmschrijving { get; set; }
        public Dossier Dossier { get; set; }
        public string Dossiernummer { get; set; }
    }
    [Table("Dossier")]
    public class Dossier
    {
        [Key]
        [Column(Order = 1)]
        public string Dossiernummer { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Dossierversie { get; set; }
        [Required]
        public string Dossierreferentie { get; set; }
        [Required]
        public string Relatienr { get; set; }
        public ICollection<Artikel> Artikels { get; set; }
    }
