    public static bool Attempt_CreateUser(string username, string password)
        {
            try
            {
                DataTableAdapters.UsersTableAdapter usersTableAdapter = new DataTableAdapters.UsersTableAdapter();
                usersTableAdapter.InsertData(username, password);
    
                return true;
            }
            catch { return false; }
            
           RefreshDataSet(); 
    
        }
    
    private void RefreshDataSet()
    {
       this.MyTableAdapter.Fill(this.MyDataSet.MyTable);
    }
