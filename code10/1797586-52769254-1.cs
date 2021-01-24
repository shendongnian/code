    private void lvTest_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.NumPad2)
        {
            if (lvTest.SelectedIndex < lvTest.Items.Count -1)
            {
                lvTest.SelectedIndex++;
            }
            else
            {
                lvTest.SelectedIndex = 0;
            }
        }
        else if (e.Key == Key.NumPad8)
        {
            if (lvTest.SelectedIndex > 0)
            {
                lvTest.SelectedIndex--;
            }
            else
            {
                lvTest.SelectedIndex = lvTest.Items.Count - 1;
            }
        }
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        lvTest.Focus();
        lvTest.SelectedIndex = 0;
    }
