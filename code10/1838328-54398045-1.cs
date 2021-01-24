    public static IEnumerable<AppointmentDetail> ToAppointmentDetails(
        this IEnumerable<Customer> customers,
        IEnumerable<Appointment> appointments)
    {
        return customers.GroupJoin(appointments,     // GroupJoin customer and appointments
            customer => customer.CustomerId,         // from every customer take the customerId,
            appointment => appointment.CustomerId,   // from every appointment take the CustomerId,
            // from every Customer with all his matching Appointments make one new AppointmentDetail 
            (customer, appointments => new AppointmentDetail 
            {
                CustomerId = customer.CustomerId,
                TotalAppointments = appointments.Count(),
                MissedAppointments = appointments
                     .Where(appointment => appointment.IsMissed)
                     .ToList(),
                ...
            });
    }
