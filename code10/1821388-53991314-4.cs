    private void dgScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        int i = 0;
        DataGrid dg = (DataGrid)sender;
        foreach (GetFlatObservationsResult o in dg.ItemsSource)
        {
            DataGridRow v = (DataGridRow)dg.ItemContainerGenerator.ContainerFromItem(o);
            if(v!=null)
            {
                //i is the index of the first visable row
                //do some stuff
                return;
            }
            i++;
        }
    }
