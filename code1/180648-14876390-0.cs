    private void MonthCalendar1_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
    {
    //Display the dates for selected range
    Label1.Text = "Dates Selected from :" + (MonthCalendar1.SelectionRange.Start() + " to " + MonthCalendar1.SelectionRange.End);
    
    //To display single selected of date
    //MonthCalendar1.MaxSelectionCount = 1;
    
    //To display single selected of date use MonthCalendar1.SelectionRange.Start/ MonthCalendarSelectionRange.End
    Label2.Text = "Date Selected :" + MonthCalendar1.SelectionRange.Start;
    }
