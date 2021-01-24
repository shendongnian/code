    public  class InfoAppointment : Entity
    {
      public Guid InfoAppointmentId { get; set; }
      // other properties
      public virtual ICollection<Boat> Boats { get; set; }
      public virtual InfoWeather infoWeather { get; set; }
    }
    public  class Boat : Entity
    {
       public Guid BoatId {get; set;}
       [ForeignKey("InfoAppointment")]
       public Guid InfoAppointmentId { get; set; }
       // other properties
       public virtual InfoAppointment InfoAppointment { get; set; }
    }
    public  class InfoWeather : Entity
    {
      [Key,ForeignKey("InfoAppointment")]
      public Guid InfoAppointmentId { get; set; }
      // other properties
      public virtual InfoAppointment InfoAppointment { get; set; }
    }
