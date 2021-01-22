    protected void Calendar_DayRender(object sender, DayRenderEventArgs e)
    {
       //Get date in past relative to current date.
       DateTime dateInPast = DateTime.Now.Subtract(TimeSpan.FromDays(10));
       if (e.Day.Date < dateInPast || e.Day.Date > DateTime.Now)
          {
             e.Day.IsSelectable = false;
          }
    }
