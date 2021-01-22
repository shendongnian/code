    List resultsList = new List();
    try
    {
        using (DataTable resultTable = DBUtility.GetSingleDBTableResult(connectionString, "SELECT * FROM MyDBTable")) 
        {
            foreach (DataRow dataRow in resultTable.Rows) 
            {
                resultsList.Add(dataRow[0].ToString());
            }
        }
    }
    catch
    {
    }
    return resultsList;
