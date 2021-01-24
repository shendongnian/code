    sSQL = "SELECT CustomerID, CustomerName FROM dbo.Customers WHERE CustomerID = @Param0";
    MyDB MyConn = new MyDB();
    paramslist[0] = new SQLParam(SqlDbType.Int, iCustomerID);
    DataTable dt = MyConn.QueryResultsWithParams(sSQL, paramslist);
    if (dt == null || (dt.Rows.Count == 0))
    {
        responsetext.Text = "No rows returned.";
    }
    else
    {
        foreach (DataRow row in dt.Rows)
        {
            string sCustomerName = row["CustomerName"].ToString();
            //write code to display the value here. You can also skip the variable assignment and just write the values directly into the response.
        }
    }
