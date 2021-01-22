    abstract class Appointment 
    {
        public abstract string Populate(AppointmentData d);
    }
    class OtherAppointment : Appointment
    {
        public override string Populate(AppointmentData d)
        {
        }
    }
