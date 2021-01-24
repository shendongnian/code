    private void ShowDetails_btn_Click(object sender, RoutedEventArgs e)
    {
        DependencyObject depObj = (DependencyObject)sender;
        ListView innerListView = FindParent<ListView>(depObj);
        if (innerListView != null)
        {
            ListViewItem lvi = FindParent<ListViewItem>(innerListView);
            if (lvi != null)
            {
                ObservableCollection<CurrentStudentsList> students = sublist1.ItemsSource as ObservableCollection<CurrentStudentsList>;
                if (students != null)
                {
                    int index = students.IndexOf(lvi.DataContext as CurrentStudentsList);
                }
            }
        }
    }
    private static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(dependencyObject);
        if (parent == null) return null;
        var parentT = parent as T;
        return parentT ?? FindParent<T>(parent);
    }
