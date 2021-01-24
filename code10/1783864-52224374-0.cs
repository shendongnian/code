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
            // At this Time need the rendered visual tree //
            ////////////////////////////////////////////////
            ic.Measure(new Size(icHalfHourBlocks.ActualWidth, icHalfHourBlocks.ActualHeight));
            ic.Arrange(new Rect(0, 0, icHalfHourBlocks.ActualWidth, icHalfHourBlocks.ActualHeight));
        }
    }
