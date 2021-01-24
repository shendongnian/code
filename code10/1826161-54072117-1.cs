    session.QueryOver<A>()
        .Where(x => x.Active)
        .JoinQueryOver(x => x.BList)
        .And(Restrictions.Between(
				Projections.SqlProjection("{alias}.Year * 12 + {alias}.Month", new string[] { }, new Type.IType[] { }),
				2000 * 12 + 1,
				2010 * 12 + 3))
        .List();
