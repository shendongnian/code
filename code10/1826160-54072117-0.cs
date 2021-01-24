    session.QueryOver<A>()
        .Where(x => x.Active)
        .JoinQueryOver(x => x.BList)
        .WhereRestrictionOn(y => y.Year)
        .IsBetween(2000).And(2010)
    	.WhereRestrictionOn(y => y.Month)
    	.IsBetween(1).And(3)
        .List();
