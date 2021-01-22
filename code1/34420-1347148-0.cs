    string query = "SELECT * FROM TableName WHERE UserName IN (:Pram)";
    param = new string[2] {"Ben", "Sam" };
    OracleCommand command = new OracleCommand(query, conn);
    command.ArrayBindCount = param.Length;
    command.Parameters.Add(":Pram", OracleType.VarChar).Value = param;
