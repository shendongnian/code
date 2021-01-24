    public  class InfoAppointment : Entity
    {      
    public string Status { get; set; }
    
    public string Code{ get; set; }
    
    public string Observation{ get; set; }
    public int BoatId { get; set; }
    
    [ForeignKey("BoatId")]
    public virtual Boat Boat { get; set; }
    }
