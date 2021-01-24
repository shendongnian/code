    public async Task<Version> CreateVersion(Version version, List<Version> versions)
            {
                int retval = 0;
                DataTable dtVersions = TableConversion.EnitiesToDataTable<Version>(versions);
                pars = new DynamicParameters();// this line  resolved the issue
                pars.Add("@refVersionTable", dtVersions.AsTableValuedParameter("dbo.VersionTable"));
                pars.Add("@Retval", retval, DbType.Int32, ParameterDirection.Output);
                string CreateVersionSP = "dbo.SPCreateVersion";
                return await ExecSproc<Version>(CreateVersionSP, pars, version).ConfigureAwait(false);
            }
 
