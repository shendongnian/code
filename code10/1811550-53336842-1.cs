        private void DatePicker1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.SelectedDateSet = DatePicker1.SelectedDate.Value;
            Properties.Settings.Default.Save();
        }
