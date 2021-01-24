      public class Contact
        {
            
        	public string MATERIAL { get; set; }
        	public string MATERIAL_GROUP_1 { get; set; }
        	
            [NotMapped]
        	public string MaterialId => $"{MATERIAL} {MATERIAL_GROUP_1}";
        	
         
        }
