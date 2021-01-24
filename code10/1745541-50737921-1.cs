    public DataSet getDataSetExportToExcel()
            {
                DataSet ds = new DataSet();
                DataTable dtEmp = new DataTable("CLOT List");
                dtEmp = getAllList();
                 ds.Tables.Add(dtEmp);
                 ds.Tables[0].TableName = "Employee"; //If you which to use Mutliple Tabs
                 return ds;
              }
