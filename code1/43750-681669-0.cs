      for (int col = 0; col < SqlReader.FieldCount; col++)
      {
        Console.Write(SqlReader.GetName(col).ToString());         // Gets the column name
        Console.Write(SqlReader.GetFieldType(col).ToString());    // Gets the column type
        Console.Write(SqlReader.GetDataTypeName(col).ToString()); // Gets the column database type
      }
