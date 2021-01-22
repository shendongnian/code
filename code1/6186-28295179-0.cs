        public List<AdxCalendarItem> GetAllCalendarItems()
        {
            Outlook.Application OutlookApp = new Outlook.Application();
            List<AdxCalendarItem> result = new List<AdxCalendarItem>();
                Outlook._NameSpace session = OutlookApp.Session;
                if (session != null)
                    try
                    {
                        object stores = session.GetType().InvokeMember("Stores", BindingFlags.GetProperty, null, session, null);
                        if (stores != null)
                            try
                            {
                                int count = (int)stores.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, stores, null);
                                for (int i = 1; i <= count; i++)
                                {
                                    object store = stores.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, stores, new object[] { i });
                                    if (store != null)
                                        try
                                        {
                                            Outlook.MAPIFolder calendar = null;
                                            try
                                            {
                                                calendar = (Outlook.MAPIFolder)store.GetType().InvokeMember("GetDefaultFolder", BindingFlags.GetProperty, null, store, new object[] { Outlook.OlDefaultFolders.olFolderCalendar });
                                            }
                                            catch
                                            {
                                                continue;
                                            }
                                            if (calendar != null)
                                                try
                                                {
                                                    Outlook.Folders folders = calendar.Folders;
                                                    try
                                                    {
                                                        Outlook.MAPIFolder subfolder = null;
                                                        for (int j = 1; j < folders.Count + 1; j++)
                                                        {
                                                            subfolder = folders[j];
                                                            try
                                                            {
                                                               // add subfolder items
                                                                result.AddRange(GetAppointmentItems(subfolder));
                                                            }
                                                            finally
                                                            { if (subfolder != null) Marshal.ReleaseComObject(subfolder); }
                                                        }
                                                    }
                                                    finally
                                                    { if (folders != null) Marshal.ReleaseComObject(folders); }
                                                    // add root items
                                                    result.AddRange(GetAppointmentItems(calendar));
                                                }
                                                finally { Marshal.ReleaseComObject(calendar); }
                                        }
                                        finally { Marshal.ReleaseComObject(store); }
                                }
                            }
                            finally { Marshal.ReleaseComObject(stores); }
                    }
                    finally { Marshal.ReleaseComObject(session); }
            return result;
        }
        List<AdxCalendarItem> GetAppointmentItems(Outlook.MAPIFolder calendarFolder)
        {
            List<AdxCalendarItem> result = new List<AdxCalendarItem>();
            Outlook.Items calendarItems = calendarFolder.Items;
            try
            {
                calendarItems.IncludeRecurrences = true;
                Outlook.AppointmentItem appointment = null;
                for (int j = 1; j < calendarItems.Count + 1; j++)
                {
                    appointment = calendarItems[j] as Outlook.AppointmentItem;
                    try
                    {
                        AdxCalendarItem item = new AdxCalendarItem(
                            calendarFolder.Name,
                            appointment.Subject,
                                       appointment.Location,
                                       appointment.Start,
                                       appointment.End,
                                       appointment.Start.Date,
                                       appointment.End.Date,
                                       appointment.AllDayEvent,
                                       appointment.Body);
                        result.Add(item);
                    }
                    finally
                    {
                        { Marshal.ReleaseComObject(appointment); }
                    }
                }
            }
            finally { Marshal.ReleaseComObject(calendarItems); }
            return result;
        }
    }
    public class AdxCalendarItem
    {
        public string CalendarName;
        public string Subject;
        public string Location;
        public DateTime StartTime;
        public DateTime EndTime;
        public DateTime StartDate;
        public DateTime EndDate;
        public bool AllDayEvent;
        public string Body;
        public AdxCalendarItem(string CalendarName, string Subject, string Location, DateTime StartTime, DateTime EndTime,
                                DateTime StartDate, DateTime EndDate, bool AllDayEvent, string Body)
        {
            this.CalendarName = CalendarName;
            this.Subject = Subject;
            this.Location = Location;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.AllDayEvent = AllDayEvent;
            this.Body = Body;
        }
    }
