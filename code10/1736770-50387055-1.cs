    public class Person
    {
         [JsonProperty]
         public string Name { get; protected set; }
         [JsonProperty]
         private string _BornOnDay { set {
           //try parse the string, if not successful, throw a nicely
           //formatted error with the original string and what you expect,
           //if parse is successful, set the value to BornOnDay;
         }}
         [JsonIgnore]
         public DayOfWeek BornOnDay { get; protected set; }
    }
