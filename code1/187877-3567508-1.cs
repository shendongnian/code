    private DataTable _dt = new DataTable("MyDataTable");
    public DataView GridData
    {
       get
       {
          return _dt.DefaultView;
       }
    }
