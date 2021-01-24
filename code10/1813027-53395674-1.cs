    if (VisualTreeHelper.GetParent(this) is ContentPresenter contentPresenter)
    {
        if (VisualTreeHelper.GetParent(contentPresenter) is RingsStackpanel ringStackPanel
            && RingHolder.ItemsSource is ObservableCollection<YourItemType> dataItems
            && contentPresenter.DataContext is YourItemType dataItem)
        {
            //wait for the ContentPresenter to get unloaded
            RoutedEventHandler handler = null;
            handler = (ss, ee) =>
            {
                //remove the parent-child relationship:
                ringStackPanel.RemoveElement(contentPresenter);
                contentPresenter.Unloaded -= handler;
            };
            //remove the data object
            dataItems.Remove(dataItem);
        }
    }
