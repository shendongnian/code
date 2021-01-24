    foreach (Microsoft.Office.Interop.Outlook.AppointmentItem item in outlookCalendarItems)
    {
        DataRow row = calendardata.NewRow();
        row["Subject"] = item.Subject;
        row["StartDate"] = item.Start.Date;
    }
    tblCalendar.DataSource = calendardata;
