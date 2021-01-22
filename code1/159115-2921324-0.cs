    /// <summary>
    /// Extension methods for DataRow.
    /// </summary>
    public static class DataRowExtensions
    {
        /// <summary>
        /// Converts DataRow into business object.
        /// </summary>
        /// <typeparam name="TEntity">A type that inherits EntityBase.</typeparam>
        /// <param name="dataRow">DataRow object to convert to business object.</param>
        /// <returns>business object created from DataRow.</returns>
        public static TEntity ToEntity<TEntity>(this DataRow dataRow)
            where TEntity : EntityBase, new()
        {
            TEntity entity = new TEntity();
            ExtensionHelper.TransformDataRowToEntity<TEntity, DataRow>(ref dataRow, ref entity);
            return entity;
        }
        /// <summary>
        /// Converts business object into DataRow.
        /// </summary>
        /// <typeparam name="TEntity">A type that inherits EntityBase.</typeparam>
        /// <param name="dataRow">DataRow object to convert business object into.</param>
        /// <param name="entity">Business object which needs to be converted to DataRow.</param>
        public static void FromEntity<TEntity>(this DataRow dataRow, TEntity entity)
            where TEntity : EntityBase, new()
        {
            ExtensionHelper.TransformEntityToDataRow<TEntity, DataRow>(ref entity, ref dataRow);
        }
    }
