    private void Button_Click(object sender, RoutedEventArgs e)
    {
        for (int i = listbox1.Items.Count - 1; i >= 0; i--)
            if (!IsItemVisible(listbox1, i))
                ((ListBoxItem)listbox1.Items[i]).Visibility = Visibility.Collapsed;
    }
