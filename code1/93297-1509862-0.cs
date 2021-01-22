    void dataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
            {
                DataGridRow row = e.Row;
                var c = row.DataContext as Job;         
                if (c != null && c.Status.Contains("omplete"))
                    e.Row.Foreground = new SolidColorBrush(Colors.Green);
                else
                    e.Row.Foreground = new SolidColorBrush(Colors.Red);
            }
