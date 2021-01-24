    protected void Submit_Clicked(object sender, EventArgs e)
    {
        var techName = ftechName.Text.Trim();
        // assuming your phone number control on your ASP.NET page is "rPhonenumber"
        rPhonenumber.Text = GetPhoneNumber(techName);
    }
    private const String SQL_CONNECTION = "ConnectionStrings:MobileLeasesConnectionString";
    private String GetPhoneNumber(String techName)
    {
        var result = String.Empty;
        using (var con = new System.Data.SqlClient.SqlConnection(SQL_CONNECTION))
        {
            // Give it your SQL command
            var sql = "SELECT Phone FROM MobileLeases WHERE OwnerName = @techName";
            // Create an SqlCommand instance
            var cmd = new System.Data.SqlClient.SqlCommand(sql, con);
            // Supply it with your parameter (data type and size should match whatever the value is for [MobileLeases].[OwnerName] in SQL)
            cmd.Parameters.Add("@techName", System.Data.SqlDbType.VarChar, 40).Value = techName;
            // Don't forget to open the connection!
            cmd.Connection.Open();
            // String.Format handles the case of the SELECT command returning NULL - converting that to an empty string
            result = String.Format("{0}", cmd.ExecuteScalar());
            // optionally, you can close the connection, but the 'using' statement should take care of that.
            cmd.Connection.Close();
        }
        // return your results
        return result;
    }
