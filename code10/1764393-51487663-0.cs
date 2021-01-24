    public Form1()
    {
        InitializeComponent();
        dataGridView1.DataSource = CreateTable();
    }
    private DataTable CreateTable()
    {
        var str = "ESU8\t\tBUY\t\t100\t\t2809.2500\t\tB324aV\t\t\r\nFLT.V\t\tSELL\t\t15,000\t\t1.7040\t\tB324aV\t\t\r\nTRST.TO\t\tSELL\t\t4,850\t\t7.1500\t\tB324aV\t\t\r\nYGR.TO\t\tSELL\t\t5,200\t\t5.3806\t\tB324aV\t";
        DataTable dt = new DataTable();
        dt.Columns.Add("Ticker", typeof(string));
        dt.Columns.Add("Action", typeof(string));
        dt.Columns.Add("Quantity", typeof(double));
        dt.Columns.Add("Price", typeof(double));
        dt.Columns.Add("Acc Number", typeof(string));
        str = str.Replace("\t\t", " ");
        str = str.Replace(",", ".");
        str = str.Replace("\r\n", "");
        var r = str.Split();
        int rows = r.Length / 5;
        for (int i = 0; i < rows; i++)
        { 
            dt.Rows.Add(
                r[i * 5 + 0], 
                r[i * 5 + 1],                                  
                double.Parse(r[i * 5 + 2]),
                double.Parse(r[i * 5 + 3]),
                r[i * 5 + 4]);
        }
        return dt;
    }
