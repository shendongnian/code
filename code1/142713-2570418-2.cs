    private void LoadMonths()
    {
        Sample.Timing timing = new Sample.Timing();
        cboMonths.ItemsSource = timing.GetMonthsFromToday(-120).OrderByDescending(row => row.StartDate);            
    }
    
    private void cboMonths_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (((ComboBox)sender).SelectedItem != null)
        {
            Sample.Timing.ListMonth month = (Sample.Timing.ListMonth)((ComboBox)sender).SelectedItem;
            Console.WriteLine(month.StartDate); // just showing these dates are accessible under the hood
            Console.WriteLine(month.NextStartDate); // just showing these dates are accessible under the hood
            /* use these dates in your query against data set where eventdate >= month.StartDate and eventdate < month.EndDate */
        }
    }
