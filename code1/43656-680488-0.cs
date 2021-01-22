      public enum Status {
    
        [Status(Description = "Not Available")]      
    
        Not_Available = 1,      
    
        [Status(Description = "Available For Game")] 
    
        Available_For_Game = 2,      
    
        [Status(Description = "Available For Discussion")] 
    
        Available_For_Discussion = 3,
    
      }
    
      public class StatusEnumInfo {
    
        private static StatusAttribute[] edesc; 
    
        public static String GetDescription(object e)
    
        {
    
          System.Reflection.FieldInfo f = e.GetType().GetField(e.ToString()); 
    
          StatusEnumInfo.edesc = f.GetCustomAttributes(typeof(StatusAttribute), false) as StatusAttribute[]; 
    
          if (StatusEnumInfo.edesc != null && StatusEnumInfo.edesc.Length == 1)         
    
            return StatusEnumInfo.edesc[0].Description; 
    
          else         
    
            return String.Empty;
    
        } 
    
        public static object GetEnumFromDesc(Type t, string desc)
    
        {
    
          Array x = Enum.GetValues(t); 
    
          foreach (object o in x) {
    
            if (GetDescription(o).Equals(desc)) {
    
              return o;
    
            }
    
          } return String.Empty;
    
        }
    
      }
    
      public class StatusAttribute : Attribute {
    
        public String Description { get; set; }
    
      }
    
     
    
      public class Implemenation {
    
        public void Run()
    
        {
    
          Status statusEnum = (Status)StatusEnumInfo.GetEnumFromDesc(typeof(Status), "Not Available"); 
    
          String statusString = StatusEnumInfo.GetDescription(Status.Available_For_Discussion);
    
        }
    
      }
