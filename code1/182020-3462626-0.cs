    session.CreateCriteria<Company>()
        .CreateAlias("CompanyInfo", "cnfo", InnerJoin)
    	.Add(Restrictions.In("cnfo.Group.id", new int[] {963, 1034}))
    	.SetProjection(Projections.ProjectionList()
    	    .Add(Projections.GroupProperty("cnfo.Group.id"), "CompanyInfoGroupID")
    	    .Add(Projections.RowCount(), "TotalNumberOfCompanies"))
    	.SetResultTransformer(Transformers.AliasToBean<SomeDTO>())
    	.List<SomeDTO>();
    	
    ...
    
    public class SomeDTO
    {
        public int CompanyInfoGroupID { get; set; }
    	public int TotalNumberOfCompanies { get; set; }
    }
