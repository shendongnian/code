        var columns = (chartListView.View as GridView).Columns;
        int index = -1;
        for (int i = 0; i < columns.Count; ++i)
        {
            if ((columns[i].Header as TextBlock).Text == name)
            {
                index = i;
                break;
            }
        }
        DependencyObject j = SelectedListView.ItemContainerGenerator.ContainerFromIndex(SelectedListView.SelectedIndex);
        while (!(j is GridViewRowPresenter)) j = VisualTreeHelper.GetChild(j, 0);
        return (VisualTreeHelper.GetChild(j, index) as TextBlock).Text;
    }
