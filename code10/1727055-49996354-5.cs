    using (var dbContext = new MyDbContext())
    {
        var ceremoniesNotAttendedByUser = dbContext.Appointments
            // keep only the Ceremony appointments
            // that are not attended by any Volunteer with UserName
            .Where(appointment => 
                // only ceremonies:
                appointment.Fee != null && appointment.Slots != 0
                // and not attended by any volunteer that has userName
                // = sequence of UserNames of the volunteers that attend this appointment
                //   does not contain userName
                && !appointment.Volunteers.Select(volunteer => volunteer.UserName)
                       .Contains(userName))
            // Fetch only the properties you want to display:
            .Select(ceremony=> new
            {
                Id = ceremony.Id,
                Name = ceremony.Name,
                Description = ceremony.Description,
                Location = ceremony.Location,
                Time = ceremony.Time,
                Duration = ceremony.Duration,
            })
            .ToList();
    }
