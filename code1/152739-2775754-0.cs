    // User input here
    Console.WriteLine("Enter a continent e.g. 'North America', 'Europe': ");
    string userInput = Console.ReadLine();
    string sql = "SELECT Name, HeadOfState FROM Country WHERE Continent=@Continent";
    MySqlCommand cmd = new MySqlCommand(sql, conn);
    cmd.Parameters.AddWithValue("@Continent", userInput);
    using (MySqlDataReader dr = cmd.ExecuteReader())
    {
        // etc.
    }
