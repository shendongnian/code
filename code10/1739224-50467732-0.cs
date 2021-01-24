    public class Appointment
    {
        public int AppointmentId {get;set;}
        public DateTime Date { get; set; }
        public int RoomNumber { get; set; }
        [ForeignKey("Consultant")]
        public int ConsultantId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
    
        public ApplicationUser Consultant { get; set; }
        public ApplicationUser Client { get; set; }
    }
