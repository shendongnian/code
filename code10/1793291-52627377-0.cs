     private void BindGantt()
        {
            this.ultraGanttView1.CalendarInfo = this.ultraCalendarInfo1;
            string query = "select rs.[Channel ID],c.Name from[dbo].[Reservations] rs inner join[dbo].[Channel] c on rs.[Channel ID] = c.ID group by rs.[Channel ID],c.Name";
            DataTable dt = new DataTable();
            DataTable dc = new DataTable();
            SqlConnection conn = new SqlConnection(Utilities.ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DateTime dateFrom;
            TimeSpan duration;
            string subject;
            int id;
            //get the channels' id that have reservations 
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                id = Convert.ToInt32(dt.Rows[j].ItemArray[0].ToString());  
                dc = GetChannelsReservations(id);
                //get the info of all the reservations for a channel
                ultraCalendarInfo1.Tasks.Add(DateTime.Now, TimeSpan.FromDays(0), dt.Rows[j].ItemArray[1].ToString());
                for (int i = 0; i < dc.Rows.Count; i++)
                {
                    dateFrom = Convert.ToDateTime(dc.Rows[i].ItemArray[0]);
                    TimeSpan.TryParse(dc.Rows[i].ItemArray[1].ToString(),out duration);
                    subject = dc.Rows[i].ItemArray[2].ToString();
                    ultraCalendarInfo1.Tasks[j].Tasks.Add(dateFrom, duration, subject);     
                }
            }
        }
        private DataTable GetChannelsReservations(int id) {
            string query = @"select rs.[Planned Date in],DATEDIFF(DAY, rs.[Planned Date in],rs.[Planned Date out]) as TimeSpan,c.Name+' '+p.[First Name]+' '+p.[Last Name],c.Name
                            from[dbo].[Reservations] rs
                            inner join[dbo].[Channel] c on rs.[Channel ID] = c.ID
                            inner join[dbo].[Person] p on rs.[Person ID] = p.ID
                            where rs.[Channel ID] ="+id;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Utilities.ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
