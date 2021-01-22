    public override bool OnFlushDirty( object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types )
	{
		bool result = false;
		if (entity is IAuditable) {
			var auditable = (IAuditable)entity;
			Set( x => auditable.Modifier, propertyNames, auditable, currentState, SecurityManager.Identity );
			//Set( x => auditable.DateModified, args.Persister, auditable, args.State, TwentyClock.Now );
			result = true;
		}
		
		return result;
	}
