    var rowNum = 0;
    var colNum = 0;
    
    var myResult = "";
    
    int.TryParse(textbox1.Text, out rowNum); //make sure the textbox contains a valid integer number
    int.TryParse(textbox2.Text, out colNum);
    
    if (rowNum > 0 && colNum > 0)
    {
    	string query = "SELECT* FROM tb_patient_information WHERE rownum=@para1";
    	using (var cmd = new MySqlCommand(query, connection))
    	{
    		cmd.Parameters.AddWithValue("@para1", rowNum);
    		using (var dataReader = cmd.ExecuteReader())
    		{
    			dataReader.Read();
    			myResult = dataReader.GetString(colNum);
    		}
    	}
    }
