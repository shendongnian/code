    _session.CreateCriteria<CompanyGroupInfo>()
            .Add(Restrictions.Between(
                 Projections.SqlFunction("substring",
                                         NHibernateUtil.String,
                                         Projections.Property("Name"),
                                         Projections.Constant(1),
                                         Projections.Constant(1)),
                 "0", "9"))
            .List<CompanyGroupInfo>();
