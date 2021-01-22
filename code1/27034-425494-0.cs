                DataTable dt = new DataTable("Woot");
    
                dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("ID",typeof(System.Guid)),
                new DataColumn("Name",typeof(String))
                });
    
    
                dt.Rows.Add(Guid.NewGuid(), "John");
                dt.Rows.Add(Guid.NewGuid(), "Jack");
    
                this.dataGridView1.DataSource = dt;
    
                this.textBox1.DataBindings.Add("Text", dt, "Name");
