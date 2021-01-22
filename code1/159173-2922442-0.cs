     // SQL Select Command
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand mySqlSelect = new SqlCommand("SELECT TOP (100) PERCENT Tag, COUNT(Tag) AS Counter FROM dbo.CtagCloud GROUP BY Tag HAVING (COUNT(Tag) > 3) ORDER BY Counter DESC", conn);
        mySqlSelect.CommandType = CommandType.Text;
        SqlDataAdapter mySqlAdapter = new SqlDataAdapter(mySqlSelect);
        DataSet myDataSet = new DataSet();
        mySqlAdapter.Fill(myDataSet);
        // create an instance for ArrayList
        ArrayList myArrayList = new ArrayList();
        // foreach loop to read each DataRow of DataTable stored inside the DataSet
        foreach (DataRow dRow in myDataSet.Tables[0].Rows)
        {
            // add DataRow object to ArrayList
            myArrayList.Add(dRow);
        }
