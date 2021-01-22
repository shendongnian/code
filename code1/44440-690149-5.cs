    public static int DoStuff()
    {
        using (var oCon = new SqlConnection("MyConnectionString"))
        {
            oCon.Open();
            var oCmd = CreateStoredProcCmd("sp_Name", oCon).AddParams(
                CreateSqlParam("Param1", SqlDBType.Int, 3),
                CreateSqlParam("Param2", SqlDBType.VarChar, "Hello World"),
                CreateSqlParam("Param3", SqlDBType.VarChar, ParameterDirection.Output)
            );
            oCmd.Prepare();
            oCmd.ExecuteNonQuery();
            object outVal = oCmd.Parameters["Param3"];
            return null != outVal ? outVal.ToString() : String.Empty;
        }
    }
