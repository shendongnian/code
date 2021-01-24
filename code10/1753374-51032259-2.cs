    listViewUsers.DataSource = null;
    
    dsUsers = aUser.GetUserNamesList(int.Parse(clientId));
    int rowsCount = dsUsers.Tables["UserNames"].Rows.Count;
    
    for (int i = 0; i < rowsCount; i++)
    { 
        dRow = dsUsers.Tables["UserNames"].Rows[i];
    
        lvi = new ListViewItem("item" + i, i);
        lvi.SubItems.Add(dRow["User_ID"].ToString().Trim());                  
        lvi.SubItems.Add(dRow["User Name"].ToString().Trim());
    
        listViewUsers.Items.Add(lvi);
    }
