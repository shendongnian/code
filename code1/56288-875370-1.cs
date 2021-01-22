    public IEnumerable<Category> GetCategories()
    {
        using (var connection = new MySqlConnection("CONNECTION STRING"))
        using (var command = new MySqlCommand("SELECT name FROM categories", connection))
        {
            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return new Category { name = reader.GetString(0) };
                }
            }
        }
    }
