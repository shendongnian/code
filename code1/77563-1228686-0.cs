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
    
        //add the column to the datagridview
        gvFilesOnServer.Columns.Add(colFileName);
        //fill the string array
        string[] filelist = GetFileListOnWebServer();
        var filenamesList = new BindingList<FileName>(filelist.Length); // <-- BindingList
        for (int i = 0; i < filelist.Length; i++)
            filenamesList.Add(new FileName(filelist[i]));
    
        gvFilesOnServer.DataSource=filenamesList // <-- no need of BindingSource
    }
