    public class DatePickerDateFormat
    {
        private static readonly DependencyProperty DatePickerTextBoxProperty =
            DependencyProperty.RegisterAttached("DatePickerTextBox", typeof (TextBox), typeof (DatePickerDateFormat));
        private static TextBox GetDatePickerTextBox(DependencyObject dobj)
        {
            return (TextBox) dobj.GetValue(DatePickerTextBoxProperty);
        }
        private static void SetDatePickerTextBox(DependencyObject dobj, TextBox value)
        {
            dobj.SetValue(DatePickerTextBoxProperty, value);
        }
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
                DispatcherPriority.Loaded, new Action<DatePicker>(CreateDatePickerTextBox), datePicker);
        }
        private static void CreateDatePickerTextBox(DatePicker datePicker)
        {
            SetDatePickerTextBoxTemplate(datePicker);
            /* When DatePicker gets focus it passes focus on to its DatePickerTextBox. As we've replaced it
             * a workaround is to make DatePicker unfocusable. */
            datePicker.Focusable = false;
            var binding = new Binding("SelectedDate")
                {
                    RelativeSource = new RelativeSource {AncestorType = typeof (DatePicker)},
                    Converter = new DatePickerDateTimeConverter(),
                    ConverterParameter = new Tuple<DatePicker, string>(datePicker, GetDateFormat(datePicker))
                };
            GetDatePickerTextBox(datePicker).SetBinding(TextBox.TextProperty, binding);
            datePicker.KeyUp -= DatePickerOnKeyUp;
            datePicker.KeyUp += DatePickerOnKeyUp;
        }
        private static void SetDatePickerTextBoxTemplate(DatePicker datePicker)
        {
            /* When a date is selected, by keyboard input + return or by calendar selection, and the user
             * then presses return, the DatePicker reverts to its own date string format until another
             * date is selected or it loses focus. A workaround is to replace its DatePickerTextbox with
             * one that it has not got event subscriptions to. */
            var parserCtx = new ParserContext();
            parserCtx.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            parserCtx.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            const string xaml =
                "<ControlTemplate>" +
                    "<DatePickerTextBox x:Name=\"PART_TextBox\" " +
                        "HorizontalContentAlignment=\"{TemplateBinding HorizontalContentAlignment}\" " +
                        "VerticalContentAlignment=\"{TemplateBinding VerticalContentAlignment}\" />" +
                "</ControlTemplate>";
            var textBox = GetTemplateTextBox(datePicker);
            textBox.Template = (ControlTemplate) XamlReader.Parse(xaml, parserCtx);
            SetDatePickerTextBox(datePicker, GetTemplateTextBox(textBox));
        }
        private static TextBox GetTemplateTextBox(Control control)
        {
            control.ApplyTemplate();
            return (TextBox) control.Template.FindName("PART_TextBox", control);
        }
        private static void DatePickerOnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
                return;
            var datePicker = (DatePicker) sender;
            var formatStr = GetDateFormat(datePicker);
            var customTextBox = GetDatePickerTextBox(datePicker);
            var dateStr = customTextBox.Text;
            datePicker.SelectedDate = DatePickerDateTimeConverter.ParseString(datePicker, formatStr, dateStr);
            customTextBox.Text = DatePickerDateTimeConverter.ParseDateTime(formatStr, datePicker.SelectedDate);
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
