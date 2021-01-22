    private void EmployeeMenuItemClick(object sender, RoutedEventArgs e)
    {
        bool found = false;
        foreach(Window w in Application.Current.Windows)
        {
            if(w.GetType() == typeof(EmployeeListViewWindow)
            {
                found = true;
                break;
            }
        }
        if(!found)
        {
            EmployeeListViewWindow ew = new EmployeeListViewWindow();
            ew.Show();
        }
    }
