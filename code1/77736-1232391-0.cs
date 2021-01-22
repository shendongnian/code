    abstract class Appointment
    {
        public abstract void Populate(AppointmentData data);
    }
    
    class DoctorsAppointment : Appointment
    {
        public override void Populate(AppointmentData data)
        {
            // implementation specific to DoctorsAppointment
        }
    }
    class OtherAppointment : Appointment
    {
        public override void Populate(AppointmentData data)
        {
            // implementation specific to OtherAppointment
        }
    }
