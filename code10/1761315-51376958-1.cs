	SomeTableEntity someTableEntity = new SomeTableEntity();
	ProjectionList column = Projections.ProjectionList();
	column.Add(Projections.Property<SomeTableEntity>(x => x.Id).WithAlias(() => someTableEntity.Id));
	Junction where = Restrictions.Conjunction();
	where.Add(Restrictions.Eq(..........));
	IList<int> idList = GetValues<SomeTableEntity, int>(column, where, 0);
