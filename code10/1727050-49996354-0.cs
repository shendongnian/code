    class Volunteer
    {
        public int Id {get; set;}
        public string UserName {get; set;}
        ...
    }
    class Appointment
    {
        public int Id {get; set}
        public <someType1> Fee {get; set;}
        public <someType2> Slots {get; set;}
        ...
    }
    // junction table
    class VolunteersAppointments
    {
        public int UserId {get; set;}
        public int AppointmentId {get; set;}
    }
