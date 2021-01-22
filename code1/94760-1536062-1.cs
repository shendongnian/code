    OdbcCommand exe = new OdbcCommand(query, conn);
    exe.Parameters.Add("ID", OdbcType.UniqueIdentifier).Value = id;
    exe.Parameters.Add("Name", OdbcType.VarChar).Value = name;
    exe.Parameters.Add("Pass", OdbcType.VarChar).Value = pass;
    exe.Parameters.Add("Email", OdbcType.VarChar).Value = email;
    exe.Parameters.Add("Address", OdbcType.VarChar).Value = address;
    exe.Parameters.Add("Age", OdbcType.Int).Value = age;
