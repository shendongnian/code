    public class Salary
    {
    
       public decimal HourlyRate { get; set; }
    
       [ValidHours]  //Custom validator
       public int NumHours { get; set; }
    
       [VerifyValidState]  
       [VerifyValidState(Ruleset="State")]  //Custom validator with ruleset
       public string State { get; set; }
    }
