	private void button1_Click(object sender, EventArgs e)
	{
		try
		{
			string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";
			OleDbConnection conn = new OleDbConnection(connStr);
			OleDbDataAdapter da = new OleDbDataAdapter("Select * from [" + testcb.SelectedItem.ToString() + "$] where [" + addcb.SelectedItem.ToString() + "] = '" + addtb.Text + "'", conn);
			dt2.Clear();
			da.Fill(dt2);
			UpdateDataSource();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}
