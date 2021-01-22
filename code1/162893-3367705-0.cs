    /// <summary> Updates auditable objects </summary>
	public class AuditEventListener : EmptyInterceptor, IPreInsertEventListener, IPreUpdateEventListener
	{
		private ISecurityManager securityManager;
		public override bool OnFlushDirty( object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, NHibernate.Type.IType[] types )
		{
			var auditable = entity as IAuditable;
			if (auditable != null) {
				Set( x => auditable.Modifier, propertyNames, auditable, currentState, SecurityManager.Identity );
				//Set( x => auditable.DateModified, args.Persister, auditable, args.State, TwentyClock.Now );
				return true;
			}
			return false;
		}
		public bool OnPreInsert( PreInsertEvent args )
		{
			var auditable = args.Entity as IAuditable;
			if (auditable != null) {
				Set( x => auditable.Creator, args.Persister.PropertyNames, auditable, args.State, SecurityManager.Identity );
				Set( x => auditable.DateAdded, args.Persister.PropertyNames, auditable, args.State, TwentyClock.Now );
			}
			return false;
		}
    // Hidden methods etc..
    }
