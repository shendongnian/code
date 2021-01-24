    public class Job
    {
    public string JobCode{get;set;}
    public string JobName{get;set;}
    public string PeriodRequired{get;set;}
    public string JobType{get;set;}
    public string JobGroupCode{get;set;}
    public DateTime DateRequired{get;set;}
    }
    
    public class JobEstimate
    {
    public string JobCode{get;set;}
    public string ProductCode{get;set;}
    public int Qty {get;set;}
    }
