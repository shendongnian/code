    void something(DataTable dt, myobj Someobject, DateTime somevariable)
    {
        string filterPattern = "user_id='{0}' AND starttime='{1}'";
        string filter = string.Format(filterPattern, 
                                      Someobject.variable, 
                                      somevariable);
        DataRow[] rows = dt.Select(filter);
    
        foreach (DataRow row in rows)
            DoSomething(row);
    }
    void DoSomething(DataRow row)
    {
    }
    public class myobj
    {
        public string variable { get; set; }
    }
