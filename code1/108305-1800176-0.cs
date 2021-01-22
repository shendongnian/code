    private void lstTimeline_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        ListBoxItem lbi = (lstTimeline.SelectedItem as ListBoxItem);
        StackPanel item = Template.FindName("stkPanel",lbi) as StackPanel;
        if (item != null)
            MessageBox.Show("StackPanel null");
        TextBlock textBox = Template.FindName("lblScreenName",item) as TextBlock;
        if (textBox != null)
            MessageBox.Show("TextBlock null");
        MessageBox.Show(textBox.Text);
    }
