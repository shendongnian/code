    string userName = ...
    IQueryable<Volunteer> volunteers = <your table of all Volunteers>
    IQueryable<Appointment> appointments = <your table of all appointments>
    // ceremonies are appointments with non-null Fee and non-zero Slots:
    var ceremonies = appointments
        .Where(appointment => appointment.Fee != null && appointment.Slots != 0);
    var volunteersWithUserName = volunteers
        .Where (volunteer => volunteer.UserName == userName);
        // if Volunteer.UserName unique, this will lead to a sequence with one element
        // if not unique, consider selection by Id
