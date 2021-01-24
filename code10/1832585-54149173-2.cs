    public  class InfoAppointment : Entity
    {
      public Guid InfoAppointmentId { get; set; }
      [ForeignKey("InfoWeather")]
      public Guid InfoWeatherId {get; set;}
      // other properties
      public virtual ICollection<Boat> Boats { get; set; }
      public virtual InfoWeather InfoWeather { get; set; }
    }
    public  class InfoWeather : Entity
    {
      [Key]
      public Guid InfoWeatherId { get; set; }
      [ForeignKey("InfoAppointment")]
      public Guid InfoAppointmentId { get; set; }
      // other properties
      public virtual InfoAppointment InfoAppointment { get; set; }
    }
