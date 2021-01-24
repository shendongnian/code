    public class Root{
    
      [JsonIgnore]
      public int? Field1 {get;set;}
    
      [JsonProperty("field1")]
      protected string Field1Data{
         {
            get { return Field1?.ToString(); }
            set { 
               if (string.IsNullOrEmpty(value))
                  Field1 = null;
               else {
                  int parsed;
                  if (Int32.TryParse(value, out parsed)){
                     Field1 = parsed;
                  } else {
                     throw new ArgumentException($"{value} could not be parsed", nameof(Field1));
                  }
               }
            } 
         }
      } 
    }
