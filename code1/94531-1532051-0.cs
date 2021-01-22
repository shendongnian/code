    public DataTable GetContractors(bool isActive)
    {
		return GetContractors((bool?)isActive);        
    }
    
    public DataTable GetAllContractors()
    {
		return GetContractors(null);
    }
    
    private DataTable GetContractors(bool? isActive)
    {
		SqlParameter paramIsActive = new SqlParameter("@IsActive", SqlDbType.Bit);
        paramIsActive.Value = isActive == null ? DBNull.Value : (object)isActive.Value;
        DataSet ds = this.SQLDataAccess.ExecSProcReturnDataset(this.AppConfig.ConnectString, "p_selContractors", paramIsActive);
        return ds.Tables[0];
    }
