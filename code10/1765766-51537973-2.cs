    public async Task<List<PendingListBranchWise>> GetBListAsync()
        {
            using (IDbConnection db = new SqlConnection(configuration.GetConnectionString("constr")))
            {
                return await (List<PendingListBranchWise>)db.QueryAsync<PendingListBranchWise>("sp_GetClientDetails", new { value = "GetBranchList" }, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            }
        }
