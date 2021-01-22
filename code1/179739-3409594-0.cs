    private void tbName_GotFocus(object sender, RoutedEventArgs e)
    {
        var container = lstRecipients.ContainerFromElement((DependencyObject)sender);
        if (container != null)
        {
            lstRecipients.SelectedItem = lstRecipients.ItemContainerGenerator
                .ItemFromContainer(container);
        }
    }
