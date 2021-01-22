cmd.CommandText = "insert_test_result";
cmd.Parameters.Add(new SQLParameter("@description", result.Description));
cmd.Parameters.Add(new SQLParameter("@message", result.Message));
try
{
     connection.Open();
     cmd.ExecuteNonQuery();
}
finally
{
     connection.Close();
}
