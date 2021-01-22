    //insert code
    System.Text.Encoding enc = System.Text.Encoding.ASCII;
    byte[] blobByteArray = enc.GetBytes(text);
    
    string sql = "insert into xxxxx (id,name,script_blob) values (?,?,?)";
    cmd = new OdbcCommand(sql, conn);
    cmd.CommandTimeout = _cmdtimeout;
    cmd.Parameters.Add("id", OdbcType.VarChar);
    cmd.Parameters["id"].Value = script_id;
    cmd.Parameters.Add("name", OdbcType.VarChar);
    cmd.Parameters["name"].Value = name;
    cmd.Parameters.Add("script_blob", OdbcType.Binary);
    cmd.Parameters["script_blob"].Value = blobByteArray;
    int i = cmd.ExecuteNonQuery();
    
    //read blob back from db
    System.Text.Encoding enc = System.Text.Encoding.ASCII;
    string sql = "select id,name,script_blob from bc_script";
    cmd = new OdbcCommand(sql, conn);
    cmd.CommandTimeout = _cmdtimeout;    
    OdbcDataReader dr2 = cmd.ExecuteReader();
    if (dr2.HasRows)
    {
        rtn = new List<BCScript>();
        while (dr2.Read())
        {
            string Script_text = enc.GetString((byte[])dr2["script_blob"]);
        }
    }
    
    cmd.Dispose();
