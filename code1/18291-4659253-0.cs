    DataTable dtAll = new DataTable();
    DataTable dt= new DataTable();
    foreach (int id in lst)
    {
        dt.Merge(GetDataTableByID(id)); // Get Data Methode return DataTable
    }
    dtAll = dt;
