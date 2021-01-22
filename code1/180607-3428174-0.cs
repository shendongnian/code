    public class Equipment 
    {
        public int Id { get; set; }
    	public IList<SiteHistory> History { get; set; }
    	public IList<EquipmentUtilization> EquipmentUtilizations { get; set; }
    	public IDictionary<DateTime, EquipmentUtilization> UtilizationsDictionary { get{...} }
    	public Site CurrentSite { get{...} }
    }
    
    public class SiteHistory {
    	public Site Site { get; set; }
    	public DateTime Arrival { get; set; }
        public DateTime? Departure { get; set; }
    }
    
    public class EquipmentUtilization {
        public int Id { get; set; }
        public Equipment Equipment { get; set; }  // is this a circular-reference back to the parent?  Might be able to omit it.
        public DateTime ReportDate { get; set; }
        public string WorkPerformed { get; set; }
    }
