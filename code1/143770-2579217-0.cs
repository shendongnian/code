    public class Salary
    {
    
       public decimal HourlyRate { get; set; }
    
       [ValidHours]  //Custom validator
       public int NumHours { get; set; }
    
       [VerifyValidState(Ruleset="State")]  //Custom validator with ruleset
       [VerifyValidState]  
       public string State { get; set; }
    }
