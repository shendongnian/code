    using Outlook = Microsoft.Office.Interop.Outlook;
    private void DemoAppointmentsInRange()
    {
        Outlook.Folder calFolder = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar)
            as Outlook.Folder;
        DateTime start = DateTime.Now;
        DateTime end = start.AddDays(5);
        Outlook.Items rangeAppts = GetAppointmentsInRange(calFolder, start, end);
        if (rangeAppts != null)
        {
            foreach (Outlook.AppointmentItem appt in rangeAppts)
            {
                 Debug.WriteLine("Subject: " + appt.Subject 
                     + " Start: " + appt.Start.ToString("g"));
            }
        }
    }
    /// <summary>
    /// Get recurring appointments in date range.
    /// </summary>
    /// <param name="folder"></param>
    /// <param name="startTime"></param>
    /// <param name="endTime"></param>
    /// <returns>Outlook.Items</returns>
    private Outlook.Items GetAppointmentsInRange(
        Outlook.Folder folder, DateTime startTime, DateTime endTime)
    {
        string filter = "[Start] >= '"
            + startTime.ToString("g")
            + "' AND [End] <= '"
            + endTime.ToString("g") + "'";
        Debug.WriteLine(filter);
        try
        {
            Outlook.Items calItems = folder.Items;
            calItems.IncludeRecurrences = true;
            calItems.Sort("[Start]", Type.Missing);
            Outlook.Items restrictItems = calItems.Restrict(filter);
            if (restrictItems.Count > 0)
            {
                return restrictItems;
            }
            else
            {
                return null;
            }
        }
        catch { return null; }
     }
