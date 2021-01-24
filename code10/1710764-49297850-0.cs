        public class Item
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }
    
        private void button2_Click(object sender, EventArgs e)
        	{
        	DataTable dt1 = new DataTable("dataTable1");
        	dt1.Columns.Add("Name", typeof(string));
        	dt1.Columns.Add("Quantity", typeof(int));
        
        	DataRow r = dt1.NewRow();
        	r["Name"] = "Item1";
        	r["Quantity"] = 200;
        	dt1.Rows.Add(r);
        
        	r = dt1.NewRow();
        	r["Name"] = "Item2";
        	r["Quantity"] = 200;
        	dt1.Rows.Add(r);
        
        	r = dt1.NewRow();
        	r["Name"] = "Item3";
        	r["Quantity"] = 200;
        	dt1.Rows.Add(r);
        
        	r = dt1.NewRow();
        	r["Name"] = "Item4";
        	r["Quantity"] = 200;
        	dt1.Rows.Add(r);
        
        
        	dgGridView.DataSource = dt1;
        
        	DataTable dt2 = new DataTable("dataTable1");
        	dt2.Columns.Add("Name", typeof(string));
        	dt2.Columns.Add("Quantity", typeof(int));
        
        	DataRow r2 = dt2.NewRow();
        	r2["Name"] = "Item1";
        	r2["Quantity"] = 200;
        	dt2.Rows.Add(r2);
        
        	r2 = dt2.NewRow();
        	r2["Name"] = "Item2";
        	r2["Quantity"] = 50;
        	dt2.Rows.Add(r2);
        
        	r2 = dt2.NewRow();
        	r2["Name"] = "Item3";
        	r2["Quantity"] = 200;
        	dt2.Rows.Add(r2);
        
        	dataGridView1.DataSource = dt2;
        
        	DataTable dtResult = new DataTable("dataTable1");
        	dtResult.Columns.Add("Name", typeof(string));
        	dtResult.Columns.Add("Quantity", typeof(int));
        
        	List<Item> dt1Items = dt1.AsEnumerable().Select(row => new Item()
        	{
        		Name=row["Name"].ToString(),
        		Quantity =Convert.ToInt32(row["Quantity"])
        	}).ToList();
        
        	List<Item> dt2Items = dt2.AsEnumerable().Select(row => new Item()
        	{
        		Name = row["Name"].ToString(),
        		Quantity = Convert.ToInt32(row["Quantity"])
        	}).ToList();
        
        	foreach (Item item in dt1Items)
        	{
        		var matched = dt2Items.FirstOrDefault(f => f.Name == item.Name);
        		var rr = dtResult.NewRow();
        
        		if (matched == null) //Item does not exist in dataTable2 so add to dataTableResult
        		{
        			rr["Name"] = item.Name;
        			rr["Quantity"] = item.Quantity;
        			dtResult.Rows.Add(rr);
        
        			continue;
        		}
        
        		//Item does exist but the subtraction == 0 do not add.
        		if (item.Quantity - matched.Quantity == 0)
        			continue;
        
    //Else add diff to results
        		rr["Name"] = item.Name;
        		rr["Quantity"] = item.Quantity - matched.Quantity;
        		dtResult.Rows.Add(rr);
        	}
    
    	dataGridView2.DataSource = dtResult;
    }
