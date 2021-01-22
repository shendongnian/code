  DG_Operations.Columns.Add(new DataGridComboBoxColumn()
  {
     Header = "Data",
     Width = 190,
     ItemsSource = new Binding("Data"),
     SelectedValueBinding = new Binding("Operation"),
     TextBinding = new Binding("Operation")
  });
