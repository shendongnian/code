        /// <summary>
        /// Transforms DataRow into business object.
        /// </summary>
        /// <typeparam name="TEntity">A type that inherits EntityBase.</typeparam>
        /// <typeparam name="TDataRow">A type that inherits DataRow.</typeparam>
        /// <param name="dataRow">DataRow object which is transformed from business object.</param>
        /// <param name="entity">business object which is transformed into DataRow object.</param>
        public static void TransformDataRowToEntity<TEntity, TDataRow>(ref TDataRow dataRow, ref TEntity entity)
            where TDataRow : DataRow
            where TEntity : EntityBase
        {
            IQueryable<DataField> entityFields = entity.GetDataFields();
            foreach (var entityField in entityFields)
            {
                if (dataRow[entityField.DataFieldMapping.MappedField] is System.DBNull)
                {
                    entityField.Property.SetValue(entity, null, null);
                }
                else
                {
                    if (entityField.Property.GetType().IsEnum)
                    {
                        Type enumType = entityField.Property.GetType();
                        EnumConverter enumConverter = new EnumConverter(enumType);
                        object enumValue = enumConverter.ConvertFrom(dataRow[entityField.DataFieldMapping.MappedField]);
                        entityField.Property.SetValue(entity, enumValue, null);
                    }
                    else
                    {
                        entityField.Property.SetValue(entity, dataRow[entityField.DataFieldMapping.MappedField], null);
                    }
                }
            }
        }
