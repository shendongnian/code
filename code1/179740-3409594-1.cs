    private void lstRecipients_GotFocus(object sender, RoutedEventArgs e)
    {
        var selector = sender as Selector;
        if (selector != null)
        {
            var container = selector.ContainerFromElement
                ((DependencyObject)e.OriginalSource);
            if (container != null)
            {
                selector.SelectedItem = selector.ItemContainerGenerator
                    .ItemFromContainer(container);
            }
        }
    }
