    // C# - DON'T DO THIS!
    String regionName = assignedSomewhereElse();
    SQLCommand sqlCmd = DatabaseConnection.CreateCommand();
    SQLCommand sqlCmd.CommandText =
        String.Format("EXECUTE sp_InsertNewRegion '{0}'", regionName);
    sqlCmd.ExecuteNonQuery();
