    public class ConfiguracionModel
    {
       public Guid EmpresaGuid { get; set; }
       public bool MaximoHabilitado { get; set; }
       public int MontoMaximo { get; set; }
       public Guid Moneda { get; set; }
       [Range(0.0, double.MaxValue)]
       [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
       public Double ValorKilometro { get; set; }
    }
