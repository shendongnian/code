    static string getMRF_No(string prefixCharFromDropDownList)
    {
    	string year = DateTime.Now.Date.ToString("yyyyMMdd");
    
    	string mrfNo = "";
    
    	SqlConnection connUser = new SqlConnection("Server=130.185.76.162;Database=StackOverflow;UID=sa;PWD=$1@mssqlICW;connect timeout=10000");
    	SqlCommand cmd = new SqlCommand(
    		$"SELECT MAX(MRF_NO) as MaxID FROM incMRF where MRF_NO like '{prefixCharFromDropDownList}%'"
    		,connUser
    		);
    	connUser.Open();
    	SqlDataReader sdr = cmd.ExecuteReader();
    	while (sdr.Read())
    	{
    		mrfNo = sdr["MaxID"].ToString();
    	}
    	if (mrfNo == "")
    	{
    		mrfNo = prefixCharFromDropDownList +  year + "000";
    	}
    	else
    	{
    		mrfNo = prefixCharFromDropDownList +  (long.Parse(mrfNo.Substring(1)) + 1).ToString().PadLeft(2);
    	}
    
    	sdr.Close();
    	cmd = new SqlCommand($"INSERT INTO incMRF (MRF_NO) values ('{mrfNo}')",connUser);
    	cmd.ExecuteNonQuery();
    	connUser.Close();
    	//txtMRFNo.Text = prefixCharFromDropDownList + i.ToString();
    	return mrfNo;
    
    }
