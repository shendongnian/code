    OleDbCommand myCommand = new OleDbCommand();
    myCommand.CommandText = query;
    //TODO: Review the datatypes and lengths for these parameters
    OleDbParameter myParm = myCommand.Parameters.Add("@uname", OleDbType.VarChar, 50);
    myParm.Value = textBox1.Text;
    myParm = myCommand.Parameters.Add("@pass", OleDbType.VarChar, 50);
    myParm.Value = textBox2.Text;
    myConnection.Open();
    myCommand.ExecuteNonQuery();
    myConnection.Close();
