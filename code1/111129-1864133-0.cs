    public Form2()
    {
        InitializeComponent();
    
        CreateData();
    }
    
    private void CreateData()
    {
        var dtb = new DataTable();
        dtb.Columns.Add("Column1");
        dtb.Columns.Add("Column2");
        dtb.Columns.Add("Column3");
    
        var dt = DateTime.Now;
        var rand = new Random();
    
        for (var i = 0; i < 10; i++)
        {
            var r = dtb.NewRow();
    
            r.ItemArray = new object[] {dt.ToString("ddd"), dt.ToString("MMM"), dt};
            dt = dt.AddDays(rand.Next(30));
    
            dtb.Rows.Add(r);
        }
    
        dataGridView1.DataSource = dtb;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        var bds = new List<DateTime>();
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            DateTime dt;
            var b = DateTime.TryParse(row.Cells[row.Cells.Count - 1].Value+"", out dt);
            if(!b) continue;
    
            bds.Add(dt);
        }
    
        cal.BoldedDates = bds.ToArray();
    }
