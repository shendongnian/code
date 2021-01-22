    public void GetAllCalendarItems()
            {
                DataTable sample = new DataTable(); //Sample Data
                sample.Columns.Add("Subject", typeof(string));
                sample.Columns.Add("Location", typeof(string));
                sample.Columns.Add("StartTime", typeof(DateTime));
                sample.Columns.Add("EndTime", typeof(DateTime));
                sample.Columns.Add("StartDate", typeof(DateTime));
                sample.Columns.Add("EndDate", typeof(DateTime));
                sample.Columns.Add("AllDayEvent", typeof(bool));
                sample.Columns.Add("Body", typeof(string));
    
    
                listViewContacts.Items.Clear();
                oApp = new Outlook.Application();
                oNS = oApp.GetNamespace("MAPI");
                oCalenderFolder = oNS.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderCalendar);
                outlookCalendarItems = oCalenderFolder.Items;
                outlookCalendarItems.IncludeRecurrences = true;
               // DataTable sample = new DataTable();
                foreach (Microsoft.Office.Interop.Outlook.AppointmentItem item in outlookCalendarItems)
                {
                    DataRow row = sample.NewRow();
                    row["Subject"] = item.Subject;
                    row["Location"] = item.Location;
                    row["StartTime"] = item.Start.TimeOfDay.ToString();
                    row["EndTime"] = item.End.TimeOfDay.ToString();
                    row["StartDate"] = item.Start.Date;
                    row["EndDate"] = item.End.Date;
                    row["AllDayEvent"] = item.AllDayEvent;
                    row["Body"] = item.Body;
                    sample.Rows.Add(row);
                }
                sample.AcceptChanges();
                foreach (DataRow dr in sample.Rows)
                    {
                        ListViewItem lvi = new ListViewItem(dr["Subject"].ToString());
    
                        lvi.SubItems.Add(dr["Location"].ToString());
                        lvi.SubItems.Add(dr["StartTime"].ToString());
                        lvi.SubItems.Add(dr["EndTime"].ToString());
                        lvi.SubItems.Add(dr["StartDate"].ToString());
                        lvi.SubItems.Add(dr["EndDate"].ToString());
                        lvi.SubItems.Add(dr["AllDayEvent"].ToString());
                        lvi.SubItems.Add(dr["Body"].ToString());
    
                       
    
                        this.listViewContacts.Items.Add(lvi);
                    }
                oApp = null;
                oNS = null;
    
            }
