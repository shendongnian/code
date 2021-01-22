    public void GetAllCalendarItems()
    {
        Microsoft.Office.Interop.Outlook.Application oApp = null;
        Microsoft.Office.Interop.Outlook.NameSpace mapiNamespace = null;
        Microsoft.Office.Interop.Outlook.MAPIFolder CalendarFolder = null;
        Microsoft.Office.Interop.Outlook.Items outlookCalendarItems = null;
        oApp = new Microsoft.Office.Interop.Outlook.Application();
        mapiNamespace = oApp.GetNamespace("MAPI"); ;
        CalendarFolder = mapiNamespace.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);
        outlookCalendarItems = CalendarFolder.Items;
        outlookCalendarItems.IncludeRecurrences = true;
        foreach (Microsoft.Office.Interop.Outlook.AppointmentItem item in outlookCalendarItems)
        {
            if (item.IsRecurring)
            {
                Microsoft.Office.Interop.Outlook.RecurrencePattern rp = item.GetRecurrencePattern();
                DateTime first = new DateTime(2008, 8, 31, item.Start.Hour, item.Start.Minute, 0);
                DateTime last = new DateTime(2008, 10, 1);
                Microsoft.Office.Interop.Outlook.AppointmentItem recur = null;
                
                for (DateTime cur = first; cur <= last; cur = cur.AddDays(1))
                {
                    try
                    {
                        recur = rp.GetOccurrence(cur);
                        MessageBox.Show(recur.Subject + " -> " + cur.ToLongDateString());
                    }
                    catch
                    { }
                }
            }
            else
            {
                MessageBox.Show(item.Subject + " -> " + item.Start.ToLongDateString());
            }
        }
    }
