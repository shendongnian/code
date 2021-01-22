    private void SetRecipientTypeForAppt()
    {
        Outlook.AppointmentItem appt =
            Application.CreateItem(
            Outlook.OlItemType.olAppointmentItem)
            as Outlook.AppointmentItem;
        appt.Subject = "Customer Review";
        appt.MeetingStatus = Outlook.OlMeetingStatus.olMeeting;
        appt.Location = "36/2021";
        appt.Start = DateTime.Parse("10/20/2006 10:00 AM");
        appt.End = DateTime.Parse("10/20/2006 11:00 AM");
        Outlook.Recipient recipRequired =
            appt.Recipients.Add("Ryan Gregg");
        recipRequired.Type =
            (int)Outlook.OlMeetingRecipientType.olRequired;
        Outlook.Recipient recipOptional =
            appt.Recipients.Add("Peter Allenspach");
        recipOptional.Type =
            (int)Outlook.OlMeetingRecipientType.olOptional;
        Outlook.Recipient recipConf =
           appt.Recipients.Add("Conf Room 36/2021 (14) AV");
        recipConf.Type =
            (int)Outlook.OlMeetingRecipientType.olResource;
        appt.Recipients.ResolveAll();
        appt.Display(false);
    }
