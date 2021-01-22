    var master = DetachedCriteria.For<Master>()
            .CreateAlias("DetailA", "detA", JoinType.LeftOuterJoin)
            .CreateAlias("DetailB", "detB", JoinType.LeftOuterJoin)
            .SetProjection
            (
                Projections.ProjectionList()
                .Add(Projections.Property("Id"), "Id")
                .Add(Projections.Property("Name"), "MasterName")
                .Add(Projections.Property("detA.Name"), "DetailAName")
                .Add(Projections.Property("detB.Name"), "DetailBName")
            )
            .SetResultTransformer(Transformers.AliasToBean(typeof (MasterDTO)));
    		
    class MasterDTO
    {
    	public virtual int Id {get;set;}
    	public virtual string MasterName {get;set;}
    	public virtual string DetailAName {get;set;}
    	public virtual string DetailBName {get;set;}
    	
    	public MasterDTO()
    	{}
    	
    	public MasterDTO(int id, string mastername, string detailaname, string detailbname)
    	{
    		Id = id;
    		MasterName = mastername;
    		DetailAName = detailaname;
    		DetailBName = detailbname;
    	}
    }
