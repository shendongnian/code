    var ret = session
	.CreateCriteria<Invoice>()
		.SetProjection(
			Projections.Max(
				new SqlFunctionProjection("SUBSTRING", 
					NHibernateUtil.String, 
					Projections.Property("invoice_id"), 
					Projections.Constant(1), 
					Projections.Constant(5))))
		.UniqueResult();
               
   
