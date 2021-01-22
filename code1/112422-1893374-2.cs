    public static SqlCommand CreateCommand(this SqlConnection connection, string command, string[] names, object[] values )
    {
         if (names.Length != values.Length)
         {
              throw new ArgumentException("name/value mismatch");
         }
         var cmd = connection.CreateCommand();
         cmd.CommandText = command;
         for (int i = 0; i < names.Length; ++i )
         {
             cmd.Parameters.AddWithValue(names[i], values[i]);
         }
         return cmd;
    }
