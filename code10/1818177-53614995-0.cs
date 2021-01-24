    StringBuilder sqlBuilder = new StringBuilder();
    sqlBuilder.AppendLine("CREATE TABLE ResultTable2 AS"); 
    sqlBuilder.AppendLine("    SELECT Journal.name_journal, Points.name_points"); 
    sqlBuilder.AppendLine("    FROM Journal"); 
    sqlBuilder.AppendLine("    INNER JOIN Points ON Points.id_journal = Journal.id_journal");
    command = new SqliteCommand(sqlBuilder.ToString(), ActiveConnection);
    command.ExecuteNonQuery();
