    string sql = string.Format("SELECT * FROM doTable WHERE dOCode IN ({0})", string.Join(", ", parameters.Select(x => "?")));
    // ...
    int index = 0;
    foreach(var param in parameters)
    {
      command.Parameters.AddWithValue($"param{index}", param);
      index++;
    }
