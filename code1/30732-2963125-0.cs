    private void EventMessageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        listView1.Dispatcher.BeginInvoke(DispatcherPriority.Background, new ScrollToLastItemDelegate(ScrollToLastItem)); 
    }
    /// <summary>
    /// Scroll to last item, unless you have scrolled up the list
    /// </summary>
    private void ScrollToLastItem()
    {
        // Get scrollviewer
        Decorator border = System.Windows.Media.VisualTreeHelper.GetChild(listView1, 0) as Decorator;
        ScrollViewer scrollViewer = border.Child as ScrollViewer;
        double vo = scrollViewer.VerticalOffset;
        
        // assume they are all the same height
        ListBoxItem lbi = listView1.ItemContainerGenerator.ContainerFromIndex(0) as ListBoxItem;
        
        //The max number of items that the listbox can display at a time
        double NumberOfItemsOnScreen = listView1.ActualHeight / lbi.ActualHeight;
        // use previousCount in case we get multiple updates in one go
        if (m_previousCount > NumberOfItemsOnScreen) // scrollbar should be active
        {
            if (vo < (m_previousCount - NumberOfItemsOnScreen)) // you're not at the bottom
            {
                return; // don't scroll to the last item
            }
        }
        m_previousCount = listView1.Items.Count;
        // scroll to the last item
        listView1.SelectedItem = listView1.Items.GetItemAt(listViewModel1.Entries.Count - 1);
        listView1.ScrollIntoView(listView1.SelectedItem);
    }
