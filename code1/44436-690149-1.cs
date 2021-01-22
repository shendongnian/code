    public static int DoStuff()
    {
        using (var oCon = new SqlConnection("MyConnectionString"))
        {
            oCon.Open();
            var oCmd = CreateStoredProcCommand("MyStoredProc", oCon).AddParameters(
                CreateSqlParam("Param1", SqlDBType.Int, 3),
                CreateSqlParam("Param2", SqlDBType.VarChar, "Hello World"),
                CreateSqlParam("Param3", SqlDBType.VarChar, ParameterDirection.Output, 10, null)
            );
            oCmd.Prepare();
            oCmd.ExecuteNonQuery();
            object outVal = oCmd.Parameters["Param3"];
            return null != outVal ? outVal.ToString() : String.Empty;
        }
    }
