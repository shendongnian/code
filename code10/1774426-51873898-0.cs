    public FileTab()
    {
        InitializeComponent();
        AddValues();
        Loaded += (s, e) =>
        {
            DataGrid grid = dg;
            DataGridRow rowContainer = grid.ItemContainerGenerator.ContainerFromIndex(0) as DataGridRow;
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
                if (presenter != null)
                {
                    DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(0) as DataGridCell;
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
        };
    }
    private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(obj, i);
            if (child != null && child is T)
                return (T)child;
            else
            {
                T childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                    return childOfChild;
            }
        }
        return null;
    }
