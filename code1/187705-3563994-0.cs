    protected void SomeCalendar_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date < DateTime.Now)
        {
            e.Cell.Text = e.Day.Date.Day.ToString();
        }
    }
