    private void FormatCalendar()
    {
        DataTable dtCalendar = this.Utils.GetDatesForCalendar(Session["LoginId"].ToString());
        if (dtCalendar.Rows.Count != 0)
        {
            foreach (DataRow dr in dtCalendar.Rows)
            {
                if (!(System.Convert.IsDBNull(dr["LogDate"])))
                {
                    RadCalendarDay NewDay = new RadCalendarDay();
                    
                    NewDay.Date = Convert.ToDateTime(dr["LogDate"]);
                       
                    txtDate.Calendar.SpecialDays.Add(NewDay);
                    txtDate.Calendar.SpecialDays[NewDay].ItemStyle.Font.Bold = true;
                }
            }
        }
    }
