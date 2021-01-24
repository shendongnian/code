    public class Incident
    {
       public string Number { get; set; }
       public string Request { get; set; }
       public string BriefDescription { get; set; }
       public List<Caller> Caller { get; set; }
    }
