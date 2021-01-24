    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Table 
                // -------------
                // | ID | Name |
                // -------------
                
               // Please Not that: ID Column in a database should not be identity Colomn because in this example i am going to add data to ID Column explicity...                
                // List of name that we are going to save in Database.
                List<string> _names = new List<string>()
                {
                    "Rehan",
                    "Hamza",
                    "Adil",
                    "Arif",
                    "Hamid",
                    "Hadeed"
                };
    
                SqlConnection connection = new SqlConnection("Connection string goes here...");
                connection.Open();
                for (int index = 0; index < _names.Count; index++)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO tbl_names (id,name) VALUES ('"+index+"', '"+_names[index]+"')",connection);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
