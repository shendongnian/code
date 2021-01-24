    string[] guids = pguid.Split(',');
    string sqlin = "";
    int paramno = -1;
    foreach (var guid in guids)
    {
       parametercount ++;
       sqlin = sqlin + "@Param" + (string)parametercount; + ","
    }
    dbCmd3.CommandText = "SELECT * FROM tbIndex where pguid in (" + sqlin.Substring(0, sqlin.Length-1) + ")";
    for(int i = 0; i <= parametercount; i++){
        dbCmd3.Parameters.Add("@Param" + (string)i, OleDbType.VarChar).Value = guids[i].Replace("'", "");
    }
