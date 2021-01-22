       DataTable dt = new DataTable("Woot");
        dt.Columns.AddRange(new DataColumn[]{
            new DataColumn("ID",typeof(System.Guid)),
            new DataColumn("Name",typeof(String))
        });
        DataRow r = dt.NewRow();
        r["ID"] = new Guid();
        r["Name"] = "AAA";
        dt.Rows.Add(r);
        r = dt.NewRow();
        r["ID"] = new Guid();
        r["Name"] = "BBB";
        dt.Rows.Add(r);
        dataGridView1.DataSource = dt;
        this.txtName.DataBindings.Add("Text", r.Table , "Name");
