        private void dgVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            if (dg != null)
            {
                dg.Items.Refresh();
            }
            e.Handled = true;
        }
