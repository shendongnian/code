    public class Person
    {
         private string day;
         [JsonConstructor]
         public Person(string name, string bornOnDay){
             this.Name = name;
             this.day = bornOnDay;
         }
    
         public string Name { get; protected set; }
    
         public DayOfWeek BornOnDay { 
         get {
              DayOfWeek  weekday;
              if(Enum.TryParse(day, true, out weekday))
                return weekday;  
              else
                return DayOfWeek.None;//add none if no able to parse
         }
     }
