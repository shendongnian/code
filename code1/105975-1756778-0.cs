    DataSet ds = DatabaseFunctions.getEmailsBySPROC("getEmailByCircuit", sql_CircuitEmail);
    
    if (ds != null)
    {
        DataTable table = ds.Tables[0];
        HashSet<string> emails = new HashSet<string>();
        for (int idx = 0; idx < table.Rows.Count; idx++)
        {
            emails.Add(table.Rows[idx]["Email"].ToString());
        }
    }
    
    StringBuilder result = new StringBuilder();
    foreach(string email in emails)
    {
        result.Append(email + ";");
    }
                
    emailList = result.ToString();
