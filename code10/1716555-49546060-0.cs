    public class PayrollContext : IPayrollRepository
    {
         public void InsertPayroll(params SqlParameter[] parameters)
         {
             using(var connection = new SqlConnection(dbConnection))
                  using(var command = new SqlCommand(query, connection))
                  {
                       connection.Open();
                       command.Parameters.AddRange(parameters);
                       command.ExecuteNonQuery();
                  }
         }
    }
