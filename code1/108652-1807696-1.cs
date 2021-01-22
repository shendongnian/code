        /// <summary>
        /// Provides collection of all Searchable Fields.
        /// </summary>
        /// <returns>DataField collection</returns>
        public IQueryable<DataField> GetSearchableDataFields()
        {
            PropertyInfo[] properties =
                this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var entityFields = from PropertyInfo property in properties
                               where property.GetCustomAttributes(typeof(SearchableAttribute), true).Length > 0
                               select
                                   new DataField(
                                       property,
                                       (SearchableAttribute)property.GetCustomAttributes(typeof(SearchableAttribute), true)[0]);
            return entityFields.AsQueryable();
        }
