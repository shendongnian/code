    private void cbShows_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox cb = sender as ComboBox;
        if (cb.SelectedItem != null)
        {
            Show selectedShow = (Show)cb.SelectedItem;
            txtShowname.Text = selectedShow.ShowName;
            icHalfHourBlocks.DataContext = selectedShow.HalfHourItems;
            icHalfHourBlocks.ItemsSource = selectedShow.HalfHourItems;
            gridShowGrid.Visibility = Visibility.Visible;
            ////////////////////////////////////////////////
            Dispatcher.BeginInvoke(new Action(() => 
            {
                IEnumerable<Expander> elements = FindVisualChildren<Expander>(icHalfHourBlocks).Where(x => x.Tag != null && x.Tag.ToString() == "HalfHourBlock");
            }), DispatcherPriority.Render);
            ////////////////////////////////////////////////
        }
    }
