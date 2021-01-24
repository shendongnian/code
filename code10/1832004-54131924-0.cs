	public Form1()
	{
		InitializeComponent();
		comboBox1.DataSource = FillSubCatsProxy(1);
		comboBox1.DisplayMember = "Cat_Name";
		comboBox1.ValueMember = "Cat_ID";
		comboBox1.SelectedIndexChanged += (s, e) => { MessageBox.Show("Selected:" + comboBox1.SelectedValue); };
	}
	public DataTable FillSubCatsProxy(int catID)
	{
		var dt = new DataTable();
		dt.Columns.Add("Cat_Name");
		dt.Columns.Add("Cat_ID");
		dt.Rows.Add("Fish","1");
		dt.Rows.Add("Jack","2");
		return dt;
	}
	public DataTable FillSubCats(int catID)
	{
		SqlConnection con = new SqlConnection("Somewhere");
		try
		{
			con.Open();
			DataTable items = new DataTable();
			var da = new SqlDataAdapter("SELECT Cat_Name,Cat_ID FROM tblProductCategories WHERE Cat_ParentCat = " + catID, con);
			da.Fill(items);
			return items;
		}
		finally
		{
			con.Close();
		}
	}
	}
