c#
private static void ExecuteNonQueryParameters(string connectionString, string queryString, Action<SqlCommmand> sqlCommandAction)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
        try
        {
            connection.Open();
            sqlCommandAction();
            command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }
}
Usage:
c#
    ...
    ExecuteNonQueryParameters(@"INSERT INTO 
        [dbo].[Product](
        [ProductCode],
        [ProductName],
        [ProductType],
        [Brand],
        [Quantity],
        [Measurements],
        [Price]) 
        VALUES(@ProductCode,@ProductName,@ProductType,@Brand,@Quantity,@Meter,@Price)", 
        cmd=>{
            cmd.Parameters.AddWithValue("@ProductCode", txtprocode.Text);
            cmd.Parameters.AddWithValue("@ProductName", txtproname.Text);
            cmd.Parameters.AddWithValue("@ProductType", txtprotype.Text);
            cmd.Parameters.AddWithValue("@Brand", txtbrand.Text);
            cmd.Parameters.AddWithValue("@Quantity", txtquantity.Text);
            cmd.Parameters.AddWithValue("@Measurements", txtmeasurements.Text);
            cmd.Parameters.AddWithValue("@Price", txtprice.Text);
    });
    ...
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.parameters?view=netframework-4.7.2
