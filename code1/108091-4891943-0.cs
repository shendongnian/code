 protected override void OnCalendarOpened(RoutedEventArgs e)
        {
            var popup = this.Template.FindName(
                "PART_Popup", this) as Popup;
            if (popup != null && popup.Child is System.Windows.Controls.Calendar)
            {
                ((System.Windows.Controls.Calendar)popup.Child).DisplayMode = CalendarMode.Year;
            }
            ((System.Windows.Controls.Calendar)popup.Child).DisplayModeChanged += new EventHandler<CalendarModeChangedEventArgs>(DatePickerCo_DisplayModeChanged);
        }
