    void LB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        LB2.SelectedItems.Clear();
        foreach(var selected in LB1.SelectedItems)
        {
            LB2.SelectedItems.Add(selected);
        }
    }
