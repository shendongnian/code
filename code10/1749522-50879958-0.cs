    protected List<Action<ModelBuilder, DbContext>> _constraints = new List<Action<ModelBuilder, DbContext>>();
    
    public void SetConstraint<T>(Func<DbContext, Expression<Func<T, bool>>> constraint)
    	where T : class
    {
    	this._constraints.Add((mb, c) => mb.Entity<T>().HasQueryFilter(constraint(c)));
    }
    
    public void ApplyStaticConstraint(ModelBuilder modelBuilder, DbContext context)
    {
    	foreach (var applyConstraint in this._constraints)
    	{
    		applyConstraint(modelBuilder, context);
    	}
    }
