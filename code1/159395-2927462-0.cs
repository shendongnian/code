    System.Windows.Controls.ListViewItem GetListViewItemFromEvent(object sender, object originalSource)
        {
            DependencyObject depObj = originalSource as DependencyObject;
            if (depObj != null)
            {
                // go up the visual hierarchy until we find the list view item the click came from  
                // the click might have been on the grid or column headers so we need to cater for this  
                DependencyObject current = depObj;
                while (current != null && current != SoundListView)
                {
                    System.Windows.Controls.ListViewItem ListViewItem = current as System.Windows.Controls.ListViewItem;
                    if (ListViewItem != null)
                    {
                        return ListViewItem;
                    }
                    current = VisualTreeHelper.GetParent(current);
                }
            }
            return null;
        }
