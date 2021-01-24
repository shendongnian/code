    public class MyObject
    {
      [JsonProperty("year")]
      public int Year { get; set; }
    
      [JsonIgnore]
      public DateTime FullDate() {
         return new DateTime (this.Year, 1, 1, 0, 0, 0);
      } 
    }
