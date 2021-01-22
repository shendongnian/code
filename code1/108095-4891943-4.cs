 private void DatePickerCo_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            var popup = this.Template.FindName(
                "PART_Popup", this) as Popup;
            if (popup != null && popup.Child is System.Windows.Controls.Calendar)
            {
                var _calendar = popup.Child as System.Windows.Controls.Calendar;
                if (_calendar.DisplayMode == CalendarMode.Month)
                {
                    _calendar.DisplayMode = CalendarMode.Year;
                    if (IsDropDownOpen)
                    {
                        this.SelectedDate = GetSelectedMonth(_calendar.DisplayDate);
                        this.IsDropDownOpen = false;
                        ((System.Windows.Controls.Calendar)popup.Child).DisplayModeChanged -= new EventHandler<CalendarModeChangedEventArgs>(DatePickerCo_DisplayModeChanged);
                    }
                }
            }
        }
 private DateTime? GetSelectedMonth(DateTime? selectedDate)
        {
            if (selectedDate == null)
            {
                selectedDate = DateTime.Now;
            }
            int monthDifferenceStart = DateTimeHelper.CompareYearMonth(selectedDate.Value, DisplayDateRangeStart);
            int monthDifferenceEnd = DateTimeHelper.CompareYearMonth(selectedDate.Value, DisplayDateRangeEnd);
            if (monthDifferenceStart >= 0 && monthDifferenceEnd <= 0)
            {
                _selectedMonth = DateTimeHelper.DiscardDayTime(selectedDate.Value);
            }
            else
            {
                if (monthDifferenceStart < 0)
                {
                    _selectedMonth = DateTimeHelper.DiscardDayTime(DisplayDateRangeStart);
                }
                else
                {
                    Debug.Assert(monthDifferenceEnd > 0, "monthDifferenceEnd should be greater than 0!");
                    _selectedMonth = DateTimeHelper.DiscardDayTime(DisplayDateRangeEnd);
                }
            }
            return _selectedMonth;
        }
