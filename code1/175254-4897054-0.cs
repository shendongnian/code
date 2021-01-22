    dtStatusMsgs = new DataTable();     
    dtStatusMsgs.Columns.Add("StatusId", typeof(int));     
    dtStatusMsgs.Columns.Add("Status", typeof(string));     
    dtStatusMsgs.Columns.Add("StatusSortOrder", typeof(int));     
    dtStatusMsgs.Columns.Add("RowId", typeof(int));
    
    statusList.ForEach(p => dtStatusMsgs.Rows.Add(p.StatusId, p.Status, p.StatusSortOrder,p.RowId)); 
