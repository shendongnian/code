    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        if (clickedLabel != null)
        {
            MessageBox.Show(clickedLabel.Content.ToString());
        }
    }
    private void Clear_Click(object sender, RoutedEventArgs e)
    {
        if (clickedLabel != null)
        {
            MessageBox.Show(clickedLabel.Content.ToString());
        }
    }
    private Label clickedLabel;
    private void Label_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        clickedLabel = (Label)sender;
    }
