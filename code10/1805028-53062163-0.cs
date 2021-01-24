    foreach (var row in GridViewCompanies.Rows)
    {
        var compID = row.Cells[0].Value.ToString();
        var shortMessage = row.Cells[3].Value.ToString();         //get value of cells and update there and then? maybe?
        var compMessage = row.Cells[4].Value.ToString();
        SqlCommand update = new SqlCommand("UPDATE [Unity].[dbo].[Companies] SET shortMessage = @ShortCompanyMessage WHERE compID = @CompanyID", sqlConnection);
        
        update.Parameters.AddWithValue("@ShortCompanyMessage", shortMessage);   <= Here i added parameter to your command
        update.Parameters.AddWithValue("@CompanyID", compID);                   <= Here i added parameter to your command
        update.ExecuteNonQuery();
        //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(update);
    }
