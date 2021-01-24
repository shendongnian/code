    private void calDatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
    {
        if (calDatePicker.Date < DateTime.Now)
        {
            dateText.Text = "Order must be placed between this day and next 5 days.";
        }
        else
        {
            var dt = calDatePicker.Date;
            dateText.Text = dt.Value.Year.ToString() + " " + dt.Value.Month.ToString();
            counter = true;
        }            
    }
