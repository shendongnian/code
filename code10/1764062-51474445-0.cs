	//first check for user input
	if ((textBox1.Text == string.Empty) && (textBox2.Text == string.Empty))
	{
		MessageBox.Show("Provide ID and PASSWORD");
		textBox1.Clear();
		textBox2.Clear();
		textBox1.Focus();
		//exit
		return;
	}
	//then another check
	else if (textBox1.Text == string.Empty)
	{
		MessageBox.Show("select ID to delete record");
		textBox2.Clear();
		textBox1.Focus();
		//exit from method
		return;
	}
	//since code went to this line, execute deletion
	//no need to use adapter because this command won't fill anything
	SqlCommand cmd = new SqlCommand(@"DELETE FROM Demo_Table WHERE (ID = @ID)",con);
	//Please use parameters because string concatenation is BAD BAD BAD!
	cmd.Parameters.AddWithValue("@ID", textBox1.Text);
	//execute query. Count will get number of effected rows (you want it to be 1)
	count = (int)cmd.ExecuteScalar();
	if (count == 0)
	{
		MessageBox.Show("wrong ID");
	}
	else
	{
		MessageBox.Show("Record Deleted");
	}
