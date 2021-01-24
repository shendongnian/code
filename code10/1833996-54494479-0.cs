    private void dgvLogs_IsVisibleChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
    {
        if (sender is DataGrid dataGrid && dataGrid.IsVisible)
        {
            TraceViewerViewModel viewModel = (TraceViewerViewModel)DataContext;
            if (viewModel.Log != null)
                dataGrid.ScrollIntoView(viewModel.Log);
        }
    }
