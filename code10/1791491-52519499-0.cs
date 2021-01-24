    private void btnClick_upload_Data(object sender, RoutedEventArgs e)
    {
        string s = null;
        Button btn = (Button)sender;
        StackPanel sp = btn.Content as StackPanel;
        if (sp != null && sp.Children.Count > 2)
        {
            TextBlock textBlock = sp.Children[2] as TextBlock;
            if (textBlock != null)
                s = textBlock.Text;
        }
        MessageBox.Show(s);
    }
