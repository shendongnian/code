    [Serializable]
    public class Record
    {
       public DateTime LastUpdated {get; set; }
       public virtual bool ShouldSerializeLastUpdated() {return true;}
       // other useful properties ...
    }
    
    public class EmployeeRecord : Record
    {
       public string EmployeeName {get; set; }
       public override bool ShouldSerializeLastUpdated() {return false;}
       // other useful properties ...
    }
