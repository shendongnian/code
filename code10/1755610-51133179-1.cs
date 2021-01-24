    private DataTable sdt = new DataTable();
    
    private void InitDt()
    {
        sdt = new DataTable();
    
        sdt.Columns.Add("col1", typeof(string));
        sdt.Columns.Add("col2", typeof(string));
        sdt.Columns.Add("col3", typeof(string));
        sdt.Columns.Add("col4", typeof(string));
        sdt.Columns.Add("col5", typeof(string));
    
        sdt.Rows.Add(new object[] { "11", "12", "13", "14", "15" });
        sdt.Rows.Add(new object[] { "21", "22", "23", "24", "25" });
        sdt.Rows.Add(new object[] { "31", "23", "33", "34", "25" });
    }
    
    private void ShuffleDT()
    {
        Random loRan = new Random(DateTime.Now.Millisecond);
        int lnRan;
        string[] loRowValues = new string[3];
        List<int> loList;
    
        foreach (DataRow loRow in sdt.Rows)
        {
            loList = new List<int>();
            while (loList.Count < 3)
            {
                if (loList.Count == 2)
                    loList.Add(new List<int>() { 0, 1, 2 }.Except(loList).First());
                else
                {
                    lnRan = loRan.Next(0, 3);
                    if (!loList.Contains(lnRan))
                        loList.Add(lnRan);
                }
            }
    
            loRowValues[0] = loRow.Field<string>(1);
            loRowValues[1] = loRow.Field<string>(2);
            loRowValues[2] = loRow.Field<string>(3);
    
            loRow.SetField<string>(1, loRowValues[loList[0]]);
            loRow.SetField<string>(2, loRowValues[loList[1]]);
            loRow.SetField<string>(3, loRowValues[loList[2]]);
        }
    }
