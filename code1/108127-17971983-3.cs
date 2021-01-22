        /// <summary>
        ///     Prevents a bug in the DatePicker, where clicking the Dropdown open button results in Text being set to default formatting regardless of StringFormat or binding overrides
        /// </summary>
        private static void DropDownButtonPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var fe = sender as FrameworkElement;
            if (fe == null) return;
            var datePicker = fe.TryFindAncestorOrSelf<DatePicker>();
            if (datePicker == null || datePicker.SelectedDate == null) return;            
            var dropDownButton = GetTemplateButton(datePicker);
            // Dropdown button was clicked
            if (e.OriginalSource == dropDownButton && datePicker.IsDropDownOpen == false)
            {                                
                // Open dropdown
                datePicker.SetCurrentValue(DatePicker.IsDropDownOpenProperty, true);
                // Mimic everything else in the standard DatePicker dropdown opening *except* setting textbox value 
                datePicker.SetCurrentValue(DatePicker.DisplayDateProperty, datePicker.SelectedDate.Value);
                // Important otherwise calendar does not work
                dropDownButton.ReleaseMouseCapture();
                // Prevent datePicker.cs from handling this event 
                e.Handled = true;                
            }
        }
