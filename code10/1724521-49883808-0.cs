        private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
    
            var cb = new ComboBox();
            cb.DisplayMemberPath = "SomePropertyFromYourCollection";
            foreach (DataColumn test in (DataContext as EnterValueDialogViewModel).displayTable.Columns)
                Console.Out.WriteLine(test);
    
            cb.ItemsSource = (DataContext as EnterValueDialogViewModel).displayTable.Columns;
            e.Column.Header = cb;
        }
