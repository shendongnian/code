public partial class MyContext    
{
    private static Dictionary<string, Dictionary<string, int>> _fieldMaxLengths;
    partial void OnContextCreated()
    {
        InitializeFieldMaxLength();
        SavingChanges -= BeforeSave;
        SavingChanges += BeforeSave;
    }
    private void BeforeSave(object sender, EventArgs e)
    {
        StringOverflowCheck(sender);
        DateTimeZeroCheck(sender);
        CheckZeroPrimaryKey(sender); 
    }
    private static void CheckZeroPrimaryKey(object sender)
    {
        var db = (CTAdminEntities)sender;
        var modified = db.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified);
        foreach (var entry in modified.Where(entry => !entry.IsRelationship))
        {
            var entity = (EntityObject)entry.Entity;
            Debug.Assert(entity != null);
            var type = entity.GetType();
            foreach (var prop in type.GetProperties().Where(
                p => new[] { typeof(Int64), typeof(Int32), typeof(Int16) }.Contains(p.PropertyType)))
            {
                var attr = prop.GetCustomAttributes(typeof (EdmScalarPropertyAttribute), false);
                if (attr.Length > 0 && ((EdmScalarPropertyAttribute) attr[0]).EntityKeyProperty)
                {
                    long value = 0;
                    if (prop.PropertyType == typeof(Int64))
                        value = (long) prop.GetValue(entity, null);
                    if (prop.PropertyType == typeof(Int32))
                        value = (int) prop.GetValue(entity, null);
                    if (prop.PropertyType == typeof(Int16))
                        value = (short) prop.GetValue(entity, null);
                    if (value == 0)
                        throw new Exception(string.Format("PK is 0 for Table {0} Key {1}", type, prop.Name));
                    break;
                }
            }
        }
    }
    private static void DateTimeZeroCheck(object sender)
    {
        var db = (CTAdminEntities)sender;
        var modified = db.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified);
        foreach (var entry in modified.Where(entry => !entry.IsRelationship))
        {
            var entity = (EntityObject)entry.Entity;
            Debug.Assert(entity != null);
            var type = entity.GetType();
            foreach (var prop in type.GetProperties().Where(p => p.PropertyType == typeof(DateTime)))
            {
                var value = (DateTime)prop.GetValue(entity, null);
                if (value == DateTime.MinValue)
                    throw new Exception(string.Format("Datetime2 is 0 Table {0} Column {1}", type, prop.Name));
            }
            foreach (var prop in type.GetProperties().Where(
                    p => p.PropertyType.IsGenericType && 
                    p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                    p.PropertyType.GetGenericArguments()[0] == typeof(DateTime)))
            {
                var value = (DateTime?)prop.GetValue(entity, null);
                if (value == DateTime.MinValue)
                    throw new Exception(string.Format("Datetime2 is 0 Table {0} Column {1}", type, prop.Name));
            }
        }
    }
    private static void StringOverflowCheck(object sender)
    {
        var db = (CTAdminEntities)sender;
        var modified = db.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified);
        foreach (var entry in modified.Where(entry => !entry.IsRelationship))
        {
            var entity = (EntityObject)entry.Entity;
            Debug.Assert(entity != null);
            var type = entity.GetType();
            var fieldMap = _fieldMaxLengths[type.Name];
            foreach (var key in fieldMap.Keys)
            {
                var value = (string)type.GetProperty(key).GetValue(entity, null);
                if (value != null && value.Length > fieldMap[key])
                    throw new Exception(string.Format("String Overflow on Table {0} Column {1}: {2} out of {3}", type, key, value.Length, fieldMap[key]));
            }
        }
    }
        
    private void InitializeFieldMaxLength()
    {
        if (_fieldMaxLengths != null)
            return;
        _fieldMaxLengths = new Dictionary<string, Dictionary<string, int>>();
        var items = MetadataWorkspace.GetItems(DataSpace.CSpace);
        Debug.Assert(items != null);
        var tables = items.Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType);
        foreach (EntityType table in tables)
        {
            var fieldsMap = new Dictionary<string, int>();
            _fieldMaxLengths[table.Name] = fieldsMap;
            var stringFields = table.Properties.Where(p => p.DeclaringType.Name == table.Name && p.TypeUsage.EdmType.Name == "String");
            foreach (var field in stringFields)
            {
                var value = field.TypeUsage.Facets["MaxLength"].Value;
                if (value is Int32)
                    fieldsMap[field.Name] = Convert.ToInt32(value);
                else
                    // unbounded
                    fieldsMap[field.Name] = Int32.MaxValue;
            }
        }
    }
}
