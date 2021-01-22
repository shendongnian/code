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
    
    foreach (DataRow dr in sample.Rows)
                {
                    DataRow row = sample.NewRow();
                    row["Subject"] = dr.Subject;
                    row["Location"] = dr.Location;
                    row["StartTime"] = dr.Start.TimeOfDay.ToString();
                    row["EndTime"] = dr.End.TimeOfDay.ToString();
                    row["StartDate"] = dr.Start.Date;
                    row["EndDate"] = dr.End.Date;
                    row["AllDayEvent"] = dr.AllDayEvent;
                    row["Body"] = dr.Body;
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
