    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        //cn.Open();  
        //cmd.CommandText = "select * from data";
        //cmd.Connection = cn;
        //dr = cmd.ExecuteReader();
        //listView1.Columns.Clear(); // Clear previously added columns
        //listView1.Items.Clear(); // Clear previously populated items
        //listView1.View = View.Details; // Set View property
        //// Set Columns
        //listView1.Columns.Add("Id");
        //listView1.Columns.Add("Name");           
        //listView1.Columns.Add("Number");
        //listView1.Columns.Add("Date");
        //while (dr.Read())
        //{
        //    ListViewItem lv = new ListViewItem(dr[0].ToString());
        //    lv.SubItems.Add(dr[1].ToString());
        //    lv.SubItems.Add(dr[2].ToString());
        //    lv.SubItems.Add(dr[3].ToString());
        //    listView1.Items.Add(lv);
        //}
        //cn.Close();
        List<List<string>> data = new List<List<string>>();
        var row = new List<string>();
        row.Add("1");
        row.Add("Name");
        row.Add("111");
        row.Add(DateTime.Now.AddDays(-2).ToString());
        data.Add(row);
        row = new List<string>();
        row.Add("2");
        row.Add("Name");
        row.Add("222");
        row.Add(DateTime.Now.AddDays(-2).AddMinutes(-5).ToString());
        data.Add(row);
        row = new List<string>();
        row.Add("3");
        row.Add("Name");
        row.Add("333");
        row.Add(DateTime.Now.AddDays(-2).AddMinutes(-10).ToString());
        data.Add(row);
        //lv = new ListView();
        listView1.Columns.Clear();
        listView1.Items.Clear();
        listView1.View = View.Details;
        listView1.Columns.Add("Id");
        listView1.Columns.Add("Name2");
        listView1.Columns.Add("Number");
        listView1.Columns.Add("Date");
        foreach (var dr in data)
        {
            ListViewItem lv = new ListViewItem(dr[0].ToString());
            lv.SubItems.Add(dr[1].ToString());
            lv.SubItems.Add(dr[2].ToString());
            lv.SubItems.Add(dr[3].ToString());
            listView1.Items.Add(lv);
        }
    }
