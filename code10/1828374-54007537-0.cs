    public class AppointmentService
    {
    	private readonly MyContext _db;
    	
    	public AppointmentService(MyContext db) => _db = db;
    	
    	public void AddAppointment(InfoAppointments appointment)
    	{
            // Update the previous appointment's end date
    		var previousAppointment = _db.Appointments
                .OrderByDescending(e => e.EndDate)
                .FirstOrDefault();
    		if (previousAppointment != null)
    		{
    			previousAppointment.EndDate = appointment.StartDate;
    		}
    		
            // Add the new appointment
    		_db.Appointments.Add(appointment);
    		
    		_db.SaveChanges();
    	}
    }
