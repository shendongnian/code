    private EventBindingCommand<DataGridCellEditEndingEventArgs> _cellEditEndingCommand;
    
    public EventBindingCommand<DataGridCellEditEndingEventArgs> CellEditEndingCommand
    {
        get 
        { 
            return _cellEditEndingCommand ?? (
                _cellEditEndingCommand = new EventBindingCommand<DataGridCellEditEndingEventArgs>(CellEditEndingHandler)); 
        }
    }
    
    public void CellEditEndingHandler(object sender, DataGridCellEditEndingEventArgs e)
    {
        MessageBox.Show("Test");
    }
