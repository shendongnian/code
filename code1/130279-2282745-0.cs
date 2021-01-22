    public class AuditableEventListener : DefaultSaveOrUpdateEventListener, IPreUpdateEventListener
    {
        public override void OnSaveOrUpdate(SaveOrUpdateEvent @event)
        {
            Auditable a = @event.Entity as Auditable;
            if (a != null)
            {
                if (this.GetEntityState(@event.Entity, @event.EntityName, @event.Entry, @event.Session) == EntityState.Transient)
                {
                    a.create_dt = DateTime.Now;
                    a.create_by = @event.Session.Load<Staff>(CurrentStaff.Id);
                }
            }
    
            base.OnSaveOrUpdate(@event);
        }
    
        #region IPreUpdateEventListener Members
    
        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            var audit = @event.Entity as Auditable;
            if (audit == null) return false;
            
            var now = DateTime.Now;
            var user = @event.Session.Load<Staff>(CurrentStaff.Id);
    
            //Very important to keep the State and Entity synced together
            Set(@event.Persister, @event.State, "last_update_dt", now);
            Set(@event.Persister, @event.State, "last_update_by", user);
    
            audit.last_update_dt = now;
            audit.last_update_by = user;
    
            return false;
        }
    
        #endregion
    
    
        private void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
                return;
            state[index] = value;
        }
    
    }
