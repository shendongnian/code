    private void DateChanged(object sender, SelectionChangedEventArgs e)
    {
        Date2.DisplayDate = Date1.SelectedDate is null ? null : ((DateTime)Date1.SelectedDate).AddDays(1) as DateTime?;
        Date2.DisplayDateStart = Date1.SelectedDate is null ? null : ((DateTime)Date1.SelectedDate).AddDays(1) as DateTime?;
        Date2.DisplayDateEnd = Date1.SelectedDate is null ? null : ((DateTime)Date1.SelectedDate).AddDays(93) as DateTime?;
    }
