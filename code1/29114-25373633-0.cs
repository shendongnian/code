    // Create the appointment.
    Appointment appointment = new Appointment(service);
    
    // Set properties on the appointment. Add two required attendees and one optional attendee.
    appointment.Subject = "Status Meeting";
    appointment.Body = "The purpose of this meeting is to discuss status.";
    appointment.Start = new DateTime(2009, 3, 1, 9, 0, 0);
    appointment.End = appointment.Start.AddHours(2);
    appointment.Location = "Conf Room";
    appointment.RequiredAttendees.Add("user1@contoso.com");
    appointment.RequiredAttendees.Add("user2@contoso.com");
    appointment.OptionalAttendees.Add("user3@contoso.com");
    
    // Send the meeting request to all attendees and save a copy in the Sent Items folder.
    appointment.Save(SendInvitationsMode.SendToAllAndSaveCopy);
