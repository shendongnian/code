using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn, trans))
{
    var idParam = new NpgsqlParameter<Int32>("ID", NpgsqlTypes.NpgsqlDbType.Integer);
    cmd.Parameters.Add(idParam);
    var trayCodeParam = new NpgsqlParameter<String>("TRAY_CODE", NpgsqlTypes.NpgsqlDbType.Varchar);
    cmd.Parameters.Add(trayCodeParam);
    foreach (ReturnScrapDecision newRecord in NewRecords)
    {
        idParam.TypedValue = newRecord.Id;
        trayCodeParam.TypedValue = newRecord.TrayCode;
        cmd.ExecuteNonQuery();
    }
}
