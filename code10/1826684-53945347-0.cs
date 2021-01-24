    public class Boat : Entity
    {
      public Guid BoatId { get; set; }
      public virtual List<InfoAppointment> InfoAppointments { get; set; }
    } 
