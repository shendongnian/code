    SqlDataReader reader = command.ExecuteReader();
    int numRows = 0;
    DataTable dt = new DataTable();
    dt.Load(reader);
    numRows = dt.Rows.Count;
    string attended_type = "";
    for (int index = 0; index < numRows; index++)
    {
        attended_type = dt.Rows[indice2]["columnname"].ToString();
    }
  
    reader.Close();
