    foreach(var entry in ChangeTracker.Entries<IAuditable>())
    {
    ...
    case EntityState.Deleted:
    var oc = ((IObjectContextAdapter)this).ObjectContext;  //this is a DbContext
    EntityKey ek = oc.ObjectStateManager.GetObjectStateEntry(entry.Entity).EntityKey;
    var tablename = ek.EntitySetName;
    var primaryKeyField = ek.EntityKeyValues[0].Key;     //assumes only 1 primary key
    var primaryKeyValue = ek.EntityKeyValues[0].Value;
