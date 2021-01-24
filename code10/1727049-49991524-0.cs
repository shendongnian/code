    string username = Membership.GetUser().UserName;
    var getVolunteer = (from vol in db.Volunteers
                        where username == vol.Username
                        select vol).SingleOrDefault();
    var userAppointmentsIds = (from a in getVolunteer.Appointments
                                where a.Fee != null &&
                                a.Slots != 0
                                select a.CerimonyID).ToList();
    var filteredCerimonies = ceremonies
                             .Where(c => !userAppointmentsIds.Contain(c.ID))
                             .ToList();
   
