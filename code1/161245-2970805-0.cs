     static class ErrorMessage {
         public string Description { get; private set; }
         public int Ordinal { get; private set; }
         private ComplexEnum() { }
         public static readonly NotFound = new ErrorMessage() { 
             Ordinal = 0, Description = "Could not find" 
         };
         public static readonly BadRequest = new ErrorMessage() { 
             Ordinal = 1, Description = "Malformed Request" 
         };
     }
