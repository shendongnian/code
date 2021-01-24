    public RunNumberModel() //Constructor
    {
        RunNumbers.Columns.Add("x", typeof(string));
        RunNumbers.Columns["x"].ReadOnly = true;
        RunNumbers.Rows.Add("Test");
    }
