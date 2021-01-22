    public class PonySaveOrUpdateEventListener : DefaultSaveOrUpdateEventListener
    {
        protected override object EntityIsPersistent(SaveOrUpdateEvent @event)
        {
            Pony ent = @event.Entity as Pony;
			
			// I don't care if it's not a pony or if the entity doesn't need updating, call base!
            if (ent == null || !IsDirty(@event))
                return base.EntityIsPersistent(@event);
			// Do nasty dialect-specific raw SQL because using NH to update this row throws us into an infinite loop
			string tablename = ((ILockable)@event.Entry.Persister).RootTableName.ToLower();
			System.Data.IDbCommand command = ((ISession)@event.Session).Connection.CreateCommand();
			command.CommandText = String.Format("update {0} set RevisionValidTo = {1} where Id = '{2}'", tablename, CurrentRevision.Id, ent.Id);
			command.ExecuteNonQuery();
			// Make the event look like it was never persistent and force a transient insert of the entity
            ent.Id = Guid.Empty;
            @event.Entry = null;
            return EntityIsTransient(@event);
        }
        protected override object EntityIsTransient(SaveOrUpdateEvent @event)
        {
            Pony ent = @event.Entity as Pony;
            if (ent == null)
                return base.EntityIsTransient(@event);
            ent.RevisionValidFrom = Host.NextRevision;
            ent.RevisionValidTo = null;
            return base.EntityIsTransient(@event);
        }
		
        private static bool IsDirty(SaveOrUpdateEvent @event)
        {
            IEntityPersister persister = @event.Entry.Persister;
            object[] oldState = @event.Entry.LoadedState;
            object[] currentState = persister.GetPropertyValues(@event.Entity, @event.Session.EntityMode);
            Int32[] dirtyProps = persister.FindDirty(currentState, oldState, @event.Entity, @event.Session);
            return dirtyProps != null;
        }
    }
