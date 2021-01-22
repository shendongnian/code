    private void DatePicker_Opened(object sender, RoutedEventArgs e)
    {
        DatePicker datepicker = (DatePicker)sender;
        Popup popup = (Popup)datepicker.Template.FindName("PART_Popup", datepicker);
        Calendar cal = (Calendar)popup.Child;
        cal.DisplayModeChanged += Calender_DisplayModeChanged;
        cal.DisplayMode = CalendarMode.Decade;
    }
    
    private void Calender_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
    {
        Calendar calendar = (Calendar)sender;
        if (calendar.DisplayMode == CalendarMode.Month)
        {
            calendar.SelectedDate = calendar.DisplayDate;
            YearPicker.IsDropDownOpen = false;
        }
    }
