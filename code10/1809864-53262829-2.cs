    private void BtnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    private void BtnRun_Click(object sender, EventArgs e)
    {
        this.Run();
    } 
    protected virtual void Run() {
        // do stuff
    }
    private void BtnReset_Click(object sender, EventArgs e)
    {
        Reset();
    }
    protected virtual void Reset() {
        using (SqlConnection conn = new SqlConnection(Program.ConnStr))
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "rt_sp_testAOFreset";
                result = cmd.ExecuteNonQuery();
            }
        }
    }
