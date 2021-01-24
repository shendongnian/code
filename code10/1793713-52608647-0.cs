    string names = "Mark, Bob, John";
    string[] filters = names
      .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
      .Select(name => name.Trim())
      .Where(name => !string.IsNullOrEmpty(name))
      .ToArray();
    //TODO: Put the right class instead of SqlConnection
    using (var connection = new SqlConnection("ConnectionStringHere")) {
      connection.Open();
      using (var command = connection.CreateCommand()) {
        command.Connection = connection;
        command.CommandText =
          $@"select *
               from MyTable
              where Name in ({string.Join(", ", filters.Select((name, i) => $"@prm_Name{i}"))})";
        //TODO: Change AddWithValue into Add and provide the RDBMS type
        for (int i = 0; i < filters.Length; ++i)
          command.Parameters.AddWithValue($"@prm_Name{i}", filters[i]);
        using (var reader = command.ExecuteReader()) {
          ...
        }
      }
    }
