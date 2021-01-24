    class Program
    {
        static void Main(string[] args)
        {
            UpdateCustomerCommand(Guid.Parse("77ceef70-ab98-4392-835d-66c9face5f16"), "John Doe", "johndoe@acme.com");
        }
        public static string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=labdb;Integrated Security=True;Pooling=False";
        private static void UpdateCustomerCommand(Guid Id, string name, string email)
        {
            var updateCommand = "UPDATE [Customer] SET [Name] = @NAME, [EMAIL] = @EMAIL WHERE [Id] = @ID";
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(updateCommand, connection);
                command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
                command.Parameters["@ID"].Value = Id;
                command.Parameters.Add("@NAME", SqlDbType.NVarChar, 150);
                command.Parameters["@NAME"].Value = name;
                command.Parameters.Add("@EMAIL", SqlDbType.NVarChar, 100);
                command.Parameters["@EMAIL"].Value = email;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
