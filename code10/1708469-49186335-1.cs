    private string GetRowData(int row){  
        string _c;
        for(int i = 0; i < grid.Cols.Count; ++i){
             _c += (grid.GetData(row, i));
        }
        return _c;
    }
