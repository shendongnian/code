    private object selectedCell = null;
    public object SelectedCell {
        get { return this.selectedCell; }
        set {
            if (this.selectedCell != value) {
                this.selectedCell = value;
                SetPropertyChanged("SelectedCell");
            }
        }
    }
    
    public void ClearGrid(object obj) {
        var dg = obj as DataGrid;
        if (dg != null) {
            dg.UnselectAllCells();
        }
    }
