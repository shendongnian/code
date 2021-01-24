    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
    
        DateTime nextDate;
        if (dsleaveplanner != null)
        {
            foreach (DataRow dr in dsleaveplanner.Tables[0].Rows)
            {
                nextDate = (DateTime)dr["date"];
                var slot = dr["slotavailable"];
                if (nextDate == e.Day.Date)
                {
                    //This is the line where we add slotavailable column data
                    e.Cell.Controls.Add(new LiteralControl($"<p>{slot}</p>"));
                    e.Cell.BackColor = System.Drawing.Color.Pink;
                }
            }
        }
    }
