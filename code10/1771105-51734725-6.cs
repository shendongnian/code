    public sealed class EstadoViewModel
    {
      public int uf_id { get; set; }
    
      [Display(Name = "Estado")]
      public string uf_estado { get; set; }
    
      [Display(Name = "UF")]
      public string uf_sigla { get; set; }
    
      public IEnumerable<Estado> ufIE { get; set; }
    }
