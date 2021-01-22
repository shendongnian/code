            Application outlook;
            NameSpace OutlookNS;
            outlook = new ApplicationClass();
            OutlookNS = outlook.GetNamespace("MAPI");
            MAPIFolder f = OutlookNS.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
            
            CalendarSharing cs = f.GetCalendarExporter();
            cs.CalendarDetail = OlCalendarDetail.olFullDetails;
            cs.StartDate = new DateTime(2011, 11, 1);
            cs.EndDate = new DateTime(2011, 12, 31);
            cs.SaveAsICal("c:\\temp\\cal.ics");
