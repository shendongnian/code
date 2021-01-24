    Datagrid.Dispatcher.BeginInvoke(new Action(() =>
                {
        DataGrid grid = Datagrid;
        int rowIndex = 0;
        int columnIndex = 0;
        DataGridRow rowContainer = grid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
        if (rowContainer != null)
        {
            DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
            if (presenter != null)
            {
                DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex) as DataGridCell;
                if (cell != null)
                {
                    DataGridCellInfo dataGridCellInfo = new DataGridCellInfo(cell);
                    if (!grid.SelectedCells.Contains(dataGridCellInfo))
                    {
                        grid.SelectedCells.Add(dataGridCellInfo);
                    }
                    grid.CurrentCell = dataGridCellInfo;
                    grid.BeginEdit();
                }
            }
        }
    }), DispatcherPriority.Background);
