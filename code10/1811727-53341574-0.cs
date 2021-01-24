    public class CTipoGasto
    {
      public static List<CTipoGasto> listaTipoGasto = new List<CTipoGasto>();
      public string descripción { get; set; }
      public int ID { get; set; }
    
      public override string ToString() {
        return descripción;
      }
    }
