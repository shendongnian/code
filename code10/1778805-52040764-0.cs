    void Main()
    {
    	DataTable tbl1 = new DataTable();
    	DataTable tbl2 = new DataTable();
    	
    	using (SqlConnection con = new SqlConnection(@"server=.\SQLExpress;Database=Test;Trusted_Connection=yes"))
    	{
    		string query = @"with myTally (N) as (
    		     select top(10) row_number() over (order by t1.object_id)
    			 from sys.all_columns t1 
    			 cross join sys.all_columns t2)
    			 select cast(N * 1000 * rand() as int) as col1, cast(N * 100 * rand() as int) as col2
    			 from myTally";
    			 con.Open();
    		tbl1.Load(new SqlCommand(query, con).ExecuteReader());
    		tbl2.Load(new SqlCommand(query, con).ExecuteReader());
    	}
    		
    	Form f1 = new Form();
    	var dgv1 = new DataGridView { Top = 10, Left = 10, Height = 100, DataSource = tbl1 };
    	var dgv2 = new DataGridView { Top = 130, Left = 10, Height = 100, DataSource = tbl2 };
    	var btn = new Button {Top=250, Left=10, Text="Show 3rd Grid"};
    
    	f1.Controls.AddRange(new Control[] {dgv1, dgv2, btn});
    
    	btn.Click += (sender, args) =>
    	{
    		DataTable tbl3 = new DataTable();
    		tbl3.Columns.Add("Result", typeof(int));
    		for (int i = 0; i < tbl1.Rows.Count; i++)
    		{
    			tbl3.Rows.Add((int)tbl1.Rows[i]["col1"] - (int)tbl2.Rows[i]["col1"]);
    		}
    
    		Form f2 = new Form();
    		var dgv3 = new DataGridView {Dock=DockStyle.Fill, DataSource=tbl3};
    		f2.Controls.Add(dgv3);
    		f2.ShowDialog();
    	};
    
    	f1.Show();
    }
