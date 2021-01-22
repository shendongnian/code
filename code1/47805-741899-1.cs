    public int GetNumberOfArticles(string employeeIds)
    {
        System.Data.DataTable dataTable;
        System.Data.SqlClient.SqlDataAdapter dataAdapter;
        System.Data.SqlClient.SqlCommand command;
        int numberOfArticles = 0;
        command = new System.Data.SqlClient.SqlCommand();
        command.Connection = Classes.Database.SQLServer.SqlConnection;
        string params = string.Join(",", employeeIds.Select((e, i)=> "@employeeId" + i.ToString()).ToArray());
        command.CommandText = @"SELECT                          
                                   COUNT(*)
                                FROM 
                                   [Articles]
                                WHERE 
                                   [Articles].[EmployeeID] IN (" + params + ")";
        for (int i = 0; i < employeeIds.Length; i++) {
           command.Parameters.AddWithValue("@employeeId" + i.ToString(), employeeIds[i]);
        }
        
        numberOfArticles = (int)command.ExecuteScalar();
        return numberOfArticles;
    }
