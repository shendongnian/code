    ...
    private void BindGrid()
    {
        gvFilesOnServer.AutoGenerateColumns = false;
        //create the column programatically
        DataGridViewTextBoxColumn colFileName = new DataGridViewTextBoxColumn();
        DataGridViewCell cell = new DataGridViewTextBoxCell()
        {
            CellTemplate = cell, 
            Name = "Value",
            HeaderText = "File Name",
            DataPropertyName = "Value" // Tell the column which property of FileName it should use
         };
    
        gvFilesOnServer.Columns.Add(colFileName);
        var filelist = GetFileListOnWebServer().ToList();
        var filenamesList = new BindingList<FileName>(filelist); // <-- BindingList
        //Bind BindingList directly to the DataGrid, no need of BindingSource
        gvFilesOnServer.DataSource = filenamesList 
    }
