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
                DispatcherPriority.Loaded, new Action<DatePicker>(SetTextBoxBinding), datePicker);
        }
        private static void SetTextBoxBinding(DatePicker datePicker)
        {
            datePicker.ApplyTemplate();
            var textBox = GetTemplateTextBox(datePicker);
            var customTextBox = GetCustomTextBox(textBox);
            /* When DatePicker gets focus it passes focus on to its DatePickerTextBox. Since it has been
             * replaced a hidden textbox is swallowing focus. A workaround is to make it unfocusable. */
            datePicker.Focusable = false;
            var binding = new Binding("SelectedDate")
                {
                    RelativeSource = new RelativeSource {AncestorType = typeof (DatePicker)},
                    Converter = new DateTimeConverter(),
                    ConverterParameter = new Tuple<DatePicker, string>(datePicker, GetDateFormat(datePicker))
                };
            customTextBox.SetBinding(TextBox.TextProperty, binding);
            customTextBox.KeyUp -= CustomTextBoxOnKeyUp;
            customTextBox.KeyUp += CustomTextBoxOnKeyUp;
        }
        private static TextBox GetTemplateTextBox(Control control)
        {
            return (TextBox)control.Template.FindName("PART_TextBox", control);
        }
        private static TextBox GetCustomTextBox(TextBox textBox)
        {
            /* When a date is selected, by keyboard input + return or by calendar selection, then the
             * user presses return, the DatePicker reverts to its own date string format until another
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
            textBox.Template = (ControlTemplate) XamlReader.Parse(xaml, parserCtx);
            textBox.ApplyTemplate();
            return GetTemplateTextBox(textBox);
        }
        private static void CustomTextBoxOnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return)
                return;
            var bindingExpression =
                        BindingOperations.GetBindingExpression((DependencyObject)sender, TextBox.TextProperty);
            if (bindingExpression != null)
                bindingExpression.UpdateSource();
        }
        private class DateTimeConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var formatStr = ((Tuple<DatePicker, string>) parameter).Item2;
                var selectedDate = (DateTime?) value;
                return selectedDate.HasValue ? selectedDate.Value.ToString(formatStr) : null;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var tupleParam = ((Tuple<DatePicker, string>) parameter);
                var text = (string) value;
                DateTime date;
                var canParse = DateTime.TryParseExact(text, tupleParam.Item2, CultureInfo.CurrentCulture,
                                                      DateTimeStyles.None, out date);
                if (!canParse)
                    canParse = DateTime.TryParse(text, CultureInfo.CurrentCulture, DateTimeStyles.None, out date);
                return canParse ? date : tupleParam.Item1.SelectedDate;
            }
        }
    }
