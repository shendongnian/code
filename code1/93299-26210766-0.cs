    private void MyDataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            var row = e.Row.GetIndex();
            if (row % 2 == 0)
            {
                e.Row.Background = new SolidColorBrush(Colors.Red);
                e.Row.Foreground = new SolidColorBrush(Colors.White);
                e.Row.FontStyle = FontStyles.Italic;
            }
            else
            {
                // defaults - without these you'll get randomly colored rows
                e.Row.Background = new SolidColorBrush(Colors.Green);
                e.Row.Foreground = new SolidColorBrush(Colors.Black);
                e.Row.FontStyle = FontStyles.Normal;
            }
        }
