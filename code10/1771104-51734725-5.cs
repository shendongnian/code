    [Table("tb_estados_uf")]
    public sealed class Estado
    {
        [Key]
        public int uf_id { get; set; }
        public string uf_estado { get; set; }
    
        public string uf_sigla { get; set; }
    
        public IEnumerable<Estado> ufIE { get; set; }
    }
