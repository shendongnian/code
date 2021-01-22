    List<int> POGIDs = acl.ToIds();
    
    List<Role> visibleRoles = dc.Roles
      .Where(r => POGIDs.Contains(r.PersonOrGroupId)
      .ToList()
    
    List<int> apptIds = visibleRoles.Select(r => r.AppointmentId).ToList();
    
    List<Appointment> appointments = dc.Appointments
      .Where(appt => appt.StartDateTime < end && start < appt.EndDate)
      .Where(appt => apptIds.Contains(appt.Id))
      .OrderBy(appt => appt.StartDateTime)
      .ToList();
    
    ILookup<int, Roles> appointmentRoles = dc.Roles
      .Where(r => apptIds.Contains(r.AppointmentId))
      .ToLookup(r => r.AppointmentId);
    
    ILookup<int, Notes> appointmentNotes = dc.AppointmentNotes
      .Where(n => apptIds.Contains(n.AppointmentId));
      .ToLookup(n => n.AppointmentId);
    
    foreach(Appointment record in appointments)
    {
      int key = record.AppointmentId;
      List<Roles> theRoles = appointmentRoles[key].ToList();
      List<Notes> theNotes = appointmentNotes[key].ToList();
    }
