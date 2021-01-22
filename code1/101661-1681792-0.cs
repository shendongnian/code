    RDOSession session = new RDOSession();
    session.Logon(System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, true, System.Reflection.Missing.Value, false);
    
    RDOFolder calendar = session.GetDefaultFolder(rdoDefaultFolders.olFolderCalendar);
    
    RDOAppointmentItem oAppointment = (RDOAppointmentItem)calendar.Items.Add(rdoItemType.olAppointmentItem);
    
    oAppointment.Subject = "This is a test subject";
    oAppointment.Body = "This is a test body";
    oAppointment.Start = DateTime.Now;
    oAppointment.End = DateTime.Now.AddMinutes(15);
    oAppointment.ReminderSet = true;
    oAppointment.ReminderMinutesBeforeStart = 30;
    oAppointment.Importance = (int)rdoImportance.olImportanceNormal;
    oAppointment.BusyStatus = rdoBusyStatus.olBusy;
    
    oAppointment.Save();
    
    oAppointment = null;
    calendar = null;
    session.Logoff();
    session = null;
