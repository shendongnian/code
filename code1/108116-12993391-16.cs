    public class DatePickerCalendar
    {
        public static readonly DependencyProperty IsMonthYearProperty =
            DependencyProperty.RegisterAttached("IsMonthYear", typeof(bool), typeof(DatePickerCalendar),
                                                new PropertyMetadata(OnIsMonthYearChanged));
        public static bool GetIsMonthYear(DependencyObject dobj)
        {
            return (bool)dobj.GetValue(IsMonthYearProperty);
        }
        public static void SetIsMonthYear(DependencyObject dobj, bool value)
        {
            dobj.SetValue(IsMonthYearProperty, value);
        }
        private static void OnIsMonthYearChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {
            var datePicker = (DatePicker) dobj;
            Application.Current.Dispatcher
                .BeginInvoke(DispatcherPriority.Loaded,
                             new Action<DatePicker, DependencyPropertyChangedEventArgs>(SetCalendarEventHandlers),
                             datePicker, e);
        }
        private static void SetCalendarEventHandlers(DatePicker datePicker, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == e.OldValue)
                return;
            
            if ((bool)e.NewValue)
            {
                datePicker.CalendarOpened += DatePickerOnCalendarOpened;
                datePicker.CalendarClosed += DatePickerOnCalendarClosed;
            }
            else
            {
                datePicker.CalendarOpened -= DatePickerOnCalendarOpened;
                datePicker.CalendarClosed -= DatePickerOnCalendarClosed;
            }
        }
        private static void DatePickerOnCalendarOpened(object sender, RoutedEventArgs routedEventArgs)
        {
            var calendar = GetDatePickerCalendar(sender);
            calendar.DisplayMode = CalendarMode.Year;
            calendar.DisplayModeChanged += CalendarOnDisplayModeChanged;
        }
        private static void DatePickerOnCalendarClosed(object sender, RoutedEventArgs routedEventArgs)
        {
            var datePicker = (DatePicker) sender;
            var calendar = GetDatePickerCalendar(sender);
            datePicker.SelectedDate = calendar.SelectedDate;
            calendar.DisplayModeChanged -= CalendarOnDisplayModeChanged;
        }
        private static void CalendarOnDisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            var calendar = (Calendar) sender;
            if (calendar.DisplayMode != CalendarMode.Month)
                return;
            calendar.SelectedDate = GetSelectedCalendarDate(calendar.DisplayDate);
            var datePicker = GetCalendarsDatePicker(calendar);
            datePicker.IsDropDownOpen = false;
        }
        private static Calendar GetDatePickerCalendar(object sender)
        {
            var datePicker = (DatePicker) sender;
            var popup = (Popup) datePicker.Template.FindName("PART_Popup", datePicker);
            return ((Calendar) popup.Child);
        }
        private static DatePicker GetCalendarsDatePicker(FrameworkElement child)
        {
            var parent = (FrameworkElement) child.Parent;
            if (parent.Name == "PART_Root")
                return (DatePicker) parent.TemplatedParent;
            return GetCalendarsDatePicker(parent);
        }
        private static DateTime? GetSelectedCalendarDate(DateTime? selectedDate)
        {
            if (!selectedDate.HasValue)
                return null;
            return new DateTime(selectedDate.Value.Year, selectedDate.Value.Month, 1);
        }
    }
