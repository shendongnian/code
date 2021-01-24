    private void btnClick_upload_Data(object sender, RoutedEventArgs e)
    {
        string s = null;
        Button btn = (Button)sender;
        StackPanel sp = btn.Content as StackPanel;
        if (sp != null && sp.Children.Count > 0)
        {
            Grid grid = sp.Children[0] as Grid;
            if (grid != null && grid.Children.Count > 1)
            {
                TextBlock textBlock = grid.Children[1] as TextBlock;
                if (textBlock != null)
                    s = textBlock.Text;
            }
        }
        MessageBox.Show(s);
    }
