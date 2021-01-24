    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday || e.Day.Date.DayOfWeek == DayOfWeek.Monday)
        {
            e.Day.IsSelectable = false;
            e.Cell.BackColor = System.Drawing.Color.Black;
        }
        //Same for other days
    }
