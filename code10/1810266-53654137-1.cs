    /// <summary>
    ///     Ignore property in updates build with UpdateBuilder.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class BsonUpdateIgnoreAttribute : Attribute
    {
    }
    /// <summary>
    ///     Ignore this property in UpdateBuild if it's value is null
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class BsonUpdateIgnoreIfNullAttribute : Attribute
    {
    }
    public static class UpdateBuilder
    {
        public static UpdateDefinition<TDocument> DefinitionFor<TDocument>(TDocument document)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            var updates = _getUpdateDefinitions<TDocument>("", document);
            return Builders<TDocument>.Update.Combine(updates);
        }
        private static IList<UpdateDefinition<TDocument>> _getUpdateDefinitions<TDocument>(string prefix, object root)
        {
            var properties = root.GetType().GetProperties();
            return properties
                .Where(p => p.GetCustomAttribute<BsonUpdateIgnoreAttribute>() == null)
                .Where(p => p.GetCustomAttribute<BsonUpdateIgnoreIfNullAttribute>() == null || p.GetValue(root) != null)
                .Select(p => _getUpdateDefinition<TDocument>(p, prefix, root)).ToList();
        }
        private static UpdateDefinition<TDocument> _getUpdateDefinition<TDocument>(PropertyInfo propertyInfo,
            string prefix,
            object obj)
        {
            if (propertyInfo.PropertyType.IsClass &&
                !propertyInfo.PropertyType.Namespace.AsSpan().StartsWith("System") &&
                propertyInfo.GetValue(obj) != null)
            {
                prefix = prefix + propertyInfo.Name + ".";
                return Builders<TDocument>.Update.Combine(
                    _getUpdateDefinitions<TDocument>(prefix, propertyInfo.GetValue(obj)));
            }
            return Builders<TDocument>.Update.Set(prefix + propertyInfo.Name, propertyInfo.GetValue(obj));
        }
    }
