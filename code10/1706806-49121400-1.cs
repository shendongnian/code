    private void AllDayEventExample()
    {
        Outlook.AppointmentItem appt = Application.CreateItem(
            Outlook.OlItemType.olAppointmentItem)
            as Outlook.AppointmentItem;
        appt.Subject = "Developer's Conference";
        appt.AllDayEvent = true;
        appt.Start = DateTime.Parse("6/11/2007 12:00 AM");
        appt.End = DateTime.Parse("6/16/2007 12:00 AM");
        appt.Display(false);
    }
