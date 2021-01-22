    public class DatePickerDateFormat
    {
        public static readonly DependencyProperty DateFormatProperty =
            DependencyProperty.RegisterAttached("DateFormat", typeof (string), typeof (DatePickerDateFormat),
                                                new PropertyMetadata(OnDateTimeFormatChanged));
        public static string GetDateFormat(DependencyObject dobj)
        {
            return (string) dobj.GetValue(DateFormatProperty);
        }
        public static void SetDateFormat(DependencyObject dobj, string value)
        {
            dobj.SetValue(DateFormatProperty, value);
        }
        private static void OnDateTimeFormatChanged(DependencyObject dobj, DependencyPropertyChangedEventArgs e)
        {
            var datePicker = (DatePicker) dobj;
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Loaded, new Action<DatePicker>(ApplyDateFormat), datePicker);
        }
        private static void ApplyDateFormat(DatePicker datePicker)
        {
            var binding = new Binding("SelectedDate")
                {
                    RelativeSource = new RelativeSource {AncestorType = typeof (DatePicker)},
                    Converter = new DatePickerDateTimeConverter(),
                    ConverterParameter = new Tuple<DatePicker, string>(datePicker, GetDateFormat(datePicker))
                };
            var textBox = GetTemplateTextBox(datePicker);
            textBox.SetBinding(TextBox.TextProperty, binding);
            textBox.PreviewKeyDown -= TextBoxOnPreviewKeyDown;
            textBox.PreviewKeyDown += TextBoxOnPreviewKeyDown;
            datePicker.CalendarOpened -= DatePickerOnCalendarOpened;
            datePicker.CalendarOpened += DatePickerOnCalendarOpened;
        }
        private static TextBox GetTemplateTextBox(Control control)
        {
            control.ApplyTemplate();
            return (TextBox) control.Template.FindName("PART_TextBox", control);
        }
        private static void TextBoxOnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
                return;
            /* DatePicker subscribes to its TextBox's KeyDown event to set its SelectedDate. When this 
             * happens it sets its text to the result of its internal date parsing if Key.Return was 
             * pressed. A workaround is to stop the KeyDown event bubbling up and handling setting the
             * DatePicker.SelectedDate ourself. */
            e.Handled = true;
            var textBox = (TextBox) sender;
            var datePicker = (DatePicker) textBox.TemplatedParent;
            var dateStr = textBox.Text;
            var formatStr = GetDateFormat(datePicker);
            datePicker.SelectedDate = DatePickerDateTimeConverter.ParseString(datePicker, formatStr, dateStr);
        }
        private static void DatePickerOnCalendarOpened(object sender, RoutedEventArgs routedEventArgs)
        {
            /* When DatePicker's TextBox is not focused and its Calendar is opened by clicking its calendar button
             * it again sets its text to the result of its internal date parsing. A workaround is to set this
             * to our own string when it is opened. */
            var datePicker = (DatePicker) sender;
            var textBox = GetTemplateTextBox(datePicker);
            var formatStr = GetDateFormat(datePicker);
            textBox.Text = DatePickerDateTimeConverter.ParseDateTime(formatStr, datePicker.SelectedDate);
        }
        private class DatePickerDateTimeConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var formatStr = ((Tuple<DatePicker, string>) parameter).Item2;
                var selectedDate = (DateTime?) value;
                return ParseDateTime(formatStr, selectedDate);
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var tupleParam = ((Tuple<DatePicker, string>) parameter);
                var dateStr = (string) value;
                return ParseString(tupleParam.Item1, tupleParam.Item2, dateStr);
            }
            public static string ParseDateTime(string formatStr, DateTime? selectedDate)
            {
                return selectedDate.HasValue ? selectedDate.Value.ToString(formatStr) : null;
            }
            public static DateTime? ParseString(DatePicker datePicker, string formatStr, string dateStr)
            {
                DateTime date;
                var canParse = DateTime.TryParseExact(dateStr, formatStr, CultureInfo.CurrentCulture,
                                                      DateTimeStyles.None, out date);
                if (!canParse)
                    canParse = DateTime.TryParse(dateStr, CultureInfo.CurrentCulture, DateTimeStyles.None, out date);
                return canParse ? date : datePicker.SelectedDate;
            }
        }
    }
