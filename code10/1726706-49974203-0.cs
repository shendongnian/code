    private void SeekClick(object sender, EventArgs e)
    {
    	if (TBCusNumber.Text != "")
    	{
    		string Number = TBCusNumber.Text;
    
    		using (var Conn = new SqlConnection())
    		{
    			Conn.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApp1.Properties.Settings.DataBase"].ConnectionString;
    			using (var Cmd = new SqlCommand())
    			{
    				Cmd.Connection = Conn;
    				Cmd.CommandText = "SELECT * FROM CustomerList WHERE CustomerNumber = @Number";
    				Cmd.Parameters.AddWithValue("@Number", Number);
                    //You miss to add Conn.Open()
    		        Conn.Open();
    				using (var DataAdapter = new SqlDataAdapter(Cmd))
    				{
    					DataSet DataSet = new DataSet();
    					DataAdapter.Fill(DataSet, "CustomerList");
    					CusView.DataSource = DataSet;
    					CusView.DataMember = "CustomerList";
    				}
    			}
    		}
    	}
    }
