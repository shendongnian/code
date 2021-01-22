    public DataTable dt0 = new DataTable();
    public DataTable dt1 = new DataTable();
    public DataTable dt2 = new DataTable();
    
    public void findall()
    {
        DataTable temp;
        for (int i = 0; i < 3; i++)
            temp = (DataTable)this.GetType().GetField("dt" + i.ToString()).GetValue(this);
    }
