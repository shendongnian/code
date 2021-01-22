        private static void ApplyDateFormat(DatePicker datePicker)
        {
            var binding = new Binding("SelectedDate")
                          {
                              RelativeSource = new RelativeSource { AncestorType = typeof(DatePicker) },
                              Converter = new DatePickerDateTimeConverter(),
                              ConverterParameter = new Tuple<DatePicker, string>(datePicker, GetDateFormat(datePicker)),
                              StringFormat = GetDateFormat(datePicker) // This is also new but didnt seem to help
                          };
            
            var textBox = GetTemplateTextBox(datePicker);
            textBox.SetBinding(TextBox.TextProperty, binding);
            textBox.PreviewKeyDown -= TextBoxOnPreviewKeyDown;
            textBox.PreviewKeyDown += TextBoxOnPreviewKeyDown;
            var dropDownButton = GetTemplateButton(datePicker);
            datePicker.CalendarOpened -= DatePickerOnCalendarOpened;
            datePicker.CalendarOpened += DatePickerOnCalendarOpened;
            // Handle Dropdownbutton PreviewMouseUp to prevent issue of flickering textboxes
            dropDownButton.PreviewMouseUp -= DropDownButtonPreviewMouseUp;
            dropDownButton.PreviewMouseUp += DropDownButtonPreviewMouseUp;
        }
        private static ButtonBase GetTemplateButton(DatePicker datePicker)
        {
            return (ButtonBase)datePicker.Template.FindName("PART_Button", datePicker);
        }
