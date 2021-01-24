    namespace InsertingArrayToSqlDatabase
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Table. (tbl_names)
                // ------------
                // | Id | Name|
                // ------------
    
                string[] names = new string[5] { "name1", "name2", "name3", "name4", "name5", };
    
                SqlConnection connection = new SqlConnection("ConnectionString goes here.");
                connection.Open();
    
                for (int index = 0; index < names.Length; index++)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO tbl_names VALUES('"+names[index]+"')");
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
