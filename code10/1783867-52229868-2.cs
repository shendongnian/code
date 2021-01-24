        ComboBox cb = sender as ComboBox;
        if (cb.SelectedItem != null)
        {
            Show selectedShow = (Show)cb.SelectedItem;
            txtShowname.Text = selectedShow.ShowName;
            icHalfHourBlocks.DataContext = selectedShow.HalfHourItems;
            icHalfHourBlocks.ItemsSource = selectedShow.HalfHourItems;
            IcHalfHourBlocks.UpdateLayout(); // <-- My new solution
            IEnumerable<Expander> elements = FindVisualChildren<Expander>(icHalfHourBlocks)
                .Where(x => x.Tag != null && x.Tag.ToString() == "HalfHourBlock");
            gridShowGrid.Visibility = Visibility.Visible;
        }
    }
