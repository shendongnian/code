    ...
    private void BindGrid()
    {
        gvFilesOnServer.AutoGenerateColumns = false;
        //create the column programatically
        DataGridViewTextBoxColumn colFileName = new DataGridViewTextBoxColumn();
        DataGridViewCell cell = new DataGridViewTextBoxCell();
        colFileName.CellTemplate = cell; colFileName.Name = "Value";
        colFileName.HeaderText = "File Name";
    
        // Tell the column which property of FileName it should use
        colFileName.DataPropertyName = "Value"; 
    
        gvFilesOnServer.Columns.Add(colFileName);
        string[] filelist = GetFileListOnWebServer();
        var filenamesList = new BindingList<FileName>(); // <-- BindingList
        for (int i = 0; i < filelist.Length; i++)
            filenamesList.Add(new FileName(filelist[i]));
    
        //Bind BindingList dirctly to the DataGrid, no need of BindingSource
        gvFilesOnServer.DataSource=filenamesList 
    }
