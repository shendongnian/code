    private RelayCommand<EventInfo<DataGridCellEditEndingEventArgs>> _cellEditEndingCommand;
    
    public RelayCommand<EventInfo<DataGridCellEditEndingEventArgs>> CellEditEndingCommand
    {
        get 
        { 
            return _cellEditEndingCommand ?? (
                _cellEditEndingCommand = new RelayCommand<EventInfo<DataGridCellEditEndingEventArgs>>(
                    p => CellEditEndingHandler(p.Sender, p.EventArgs)
                )); 
        }
        set { _cellEditEndingCommand = value; }
    }
    
    public void CellEditEndingHandler(object sender, DataGridCellEditEndingEventArgs e)
    {
        MessageBox.Show("Test");
    }
