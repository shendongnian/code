    private void HeadCheck(object sender, RoutedEventArgs e, bool IsChecked)
    {
        foreach (CheckedMusicFile mf in TheMissingChildren)
        {
            mf.Checked = IsChecked;
        }
        dgMissingNames.Items.Refresh();
    }
    
    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        HeadCheck(sender, e, true);
    }
    
    private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
        HeadCheck(sender, e, false);
    }
