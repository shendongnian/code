    public static class ModelObjectFilters
    {
        /// <summary>
        /// Filters the query by ID
        /// </summary>
        /// <typeparam name="T">The IModelObject being queried</typeparam>
        /// <param name="qry">The IQueryable being extended</param>
        /// <param name="ID">The ID to filter by</param>
        /// <returns></returns>
        public static IQueryable<T> WithID<T>(this IQueryable<T> qry,
            int ID) where T : IModelObject
        {
            return qry.Where(result => result.ID == ID);
        }
    }
