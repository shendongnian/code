    private void cboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       var comboBoxItem = cboFilter.SelectedItem as ComboBoxItem;
       if(comboBoxItem == null) return; // or log an error here or something if it should not be empty.
       var query = tickets.Where(t => t.District.ToLower() == comboBoxItem.Content.ToString().ToLower());
        lstTickets.ItemsSource = null;
        lstTickets.Items.Clear();
        List<Ticket> tmp = new List<Ticket>();
        foreach (var tickets in query)
        {
            tmp.Add(tickets);
        }
        lstTickets.ItemsSource = tmp;
    }
