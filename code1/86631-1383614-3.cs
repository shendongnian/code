    public DataTable GetStages(int id)
    {
        SqlCommand cmd = GetNewCmd("dbo.GetStages");
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
        return GetTable(cmd);
    }
    public void DeleteStage(int id)
    {
        SqlCommand cmd = GetNewCmd("dbo.DeleteStage");
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
        ExecuteNonQuery(cmd);
    }
