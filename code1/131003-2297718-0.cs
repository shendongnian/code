    public abstract class Report
    {
       public int ReportID {get; set;}
       public int Timeout {get; set;}
       public string Data {get; set; }
       public abstract void Send();
    }
