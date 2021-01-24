    public string SelectedFileName
    {
       get
       {
           if (IsSelected)
               return filesDBdataGridView.SelectedCells[0].Value.ToString();
           return null;
       }
    }
    
