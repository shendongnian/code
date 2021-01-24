        public MainViewModel ViewModel => DataContext as MainViewModel;
        private void DataGrid_AutoGeneratingColumn(object sender, 
                DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = ViewModel.Columns
                                .FirstOrDefault(c => c.ColumnName == e.PropertyName);
        }
