    void DayRender(Object source, DayRenderEventArgs e) 
    {
      // Change the background color of the days in the month to Red.
      if (e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
         e.Cell.BackColor=System.Drawing.Color.Red;
    }
