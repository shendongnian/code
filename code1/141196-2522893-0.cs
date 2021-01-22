    public class YourRecord
    ...
    
    [FieldFixedLength(6)]  
    public string scheduledDepartureDate;
    
    [FieldFixedLength(4)]  
    public string scheduledDepartureTime;
    
    [FieldIgnored]  
    public DateTime scheduledDepartureDateTime;
    
    public void AfterRead(EngineBase engine, string line)
    {
        scheduledDepartureDateTime = CombineDateTime(scheduledDepartureDate, scheduledDepartureTime)                 
    }
