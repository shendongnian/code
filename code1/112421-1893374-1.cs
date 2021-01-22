    public static SqlCommand CreateCommand( this SqlConnection connection, string command, string[] names, object[] values )
    {
         if (names.Length != values.Length)
         {
              throw new ArgumentException( "name/value mismatch" );
         }
         var command = connection.CreateCommand();
         for (int i = 0; i < names.Length; ++i )
         {
             command.Parameters.AddWithValue( name[i], values[i] );
         }
         return command;
    }
