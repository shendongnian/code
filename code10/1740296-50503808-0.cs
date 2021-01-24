    static void Main(string[] args)
    {
    	DataTable dtA = new DataTable();
    	dtA.Columns.Add("ID");
    	dtA.Columns.Add("Receipt");
    	dtA.Columns.Add("Amount");
    	dtA.Columns.Add("Issued");
    
    	DataTable dtB = new DataTable();
    	dtB.Columns.Add("ID");
    	dtB.Columns.Add("Receipt");
    	dtB.Columns.Add("Amount");
    
    	for (int i = 1; i <= 10; i++)
    		dtA.Rows.Add(i, "Receipt" + i, i * 10, "");
    
    	for (int i = 1; i <= 5; i++)
    		dtB.Rows.Add(i, "Receipt" + i, i * 10);
    
    	for (int i = 0; i < dtA.Rows.Count; i++)
    	{
    		for (int j = 0; j < dtB.Rows.Count; j++)
    		{
    			if (Convert.ToInt32(dtA.Rows[i]["ID"]) == Convert.ToInt32(dtB.Rows[j]["ID"]))
    				dtA.Rows[i]["Issued"] = "Yes";
    		}
    	}
    
    	Console.ReadLine();
    }
