    [DataContract]
    public class Prestation
    {  
      // included in JSON
      [DataMember]
      public int IdPrestation { get; set; }
      [DataMember]
      public string NomPrestation { get; set; }
    
      //ignored in JSON
      public int Categorie { get; set; }
      public Nullable<int> CoifEsthe { get; set; }
      public Nullable<int> IdPrestationCategorie { get; set; }
    }
