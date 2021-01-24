    private void Delete_Commands(object sender, RoutedEventArgs e)
    {
        foreach (CommandGridItems item in CommandRows2.ItemsSource)
        {
            if (item.Delete)
            {
                // use parameter for id here !!!
                ServerDB.ExecuteDB("DELETE FROM commands where id = " + item.Command_ID);
            }
        }
        PopulateDataGrid();
    }
