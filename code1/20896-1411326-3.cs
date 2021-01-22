    public ObservableCollection<DataGridColumn> gridColumns
    {
      get
      {
        return (ObservableCollection<DataGridColumn>)GetValue(ColumnsProperty);
      }
      set
      {
        SetValue(ColumnsProperty, value);
      }
    }
    public static readonly DependencyProperty ColumnsProperty =
      DependencyProperty.Register("gridColumns",
      typeof(ObservableCollection<DataGridColumn>),
      typeof(parentControl),
      new PropertyMetadata(new ObservableCollection<DataGridColumn>()));
    public void LoadGrid()
    {
      if (gridColumns.Count > 0)
        myGrid.Columns.Clear();
      foreach (DataGridColumn c in gridColumns)
      {
        myGrid.Columns.Add(c);
      }
    }
  
