    private void monthCalendar1_MouseDown(object sender, MouseEventArgs e) {
      MonthCalendar.HitTestInfo info = monthCalendar1.HitTest(e.Location);
      if (info.HitArea == MonthCalendar.HitArea.Date) {
        if (monthCalendar1.BoldedDates.Contains(info.Time))
          monthCalendar1.RemoveBoldedDate(info.Time);
        else 
          monthCalendar1.AddBoldedDate(info.Time);
        monthCalendar1.UpdateBoldedDates();
      }
    }
