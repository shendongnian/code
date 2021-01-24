    string sql = "update table1 set name=@name where id=@id";
    MySqlParameter pId = new MySqlParameter("@id", SqlDbType.BigInt);
    MySqlParameter pName = new MySqlParameter("@name", SqlDbType.NVarchar);
    cmd.Parameters.Clear();
    cmd.CommandText = query;
    cmd.Parameters.Add(pName);
    cmd.Parameters.Add(pId);    
    foreach(DatagridViewRow dr in datagridview)
    {
        pId.Value = dr.Rows["iDColumn"].ToString();        
        pName.Value = dr.Rows["nameColumn"].ToString();
        cmd.ExecuteNonQuery();
    }
