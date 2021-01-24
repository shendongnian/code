        void ChangeDatePickerWaterMark()
        {
            var dp = datePicker as DatePicker; //datePicker is your control name
            if (dp == null) return;
            var tb = GetChildOfType<DatePickerTextBox>(dp);
            if (tb == null) return;
            var wm = tb.Template.FindName("PART_Watermark", tb) as ContentControl;
            if (wm == null) return;
            wm.Content = "...";
        }
        public static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);
                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeDatePickerWaterMark();
        }
