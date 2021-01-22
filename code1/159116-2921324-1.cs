    /// <summary>
    /// Helper methods for transforming data objects into business objects and vice versa.
    /// </summary>
    /// <remarks>
    /// <para>Most important implementation that takes care of universal transformation between business objects and data object.</para>
    /// <para>Saves programmers from writing the same old code for every object in the system.</para>
    /// </remarks>
    public static class ExtensionHelper
    {
        /// <summary>
        /// Transforms business object into DataRow.
        /// </summary>
        /// <typeparam name="TEntity">A type that inherits EntityBase.</typeparam>
        /// <typeparam name="TDataRow">A type that inherits DataRow.</typeparam>
        /// <param name="entity">business object which is transformed into DataRow object.</param>
        /// <param name="dataRow">DataRow object which is transformed from business object.</param>
        public static void TransformEntityToDataRow<TEntity, TDataRow>(ref TEntity entity, ref TDataRow dataRow)
            where TDataRow : DataRow
            where TEntity : EntityBase
        {
            IQueryable<DataField> entityFields = entity.GetDataFields();
            foreach (DataColumn dataColoumn in dataRow.Table.Columns)
            {
                if (!dataColoumn.ReadOnly)
                {
                    var entityField =
                        entityFields.Single(e => e.DataFieldMapping.MappedField.Equals(dataColoumn.ColumnName, StringComparison.OrdinalIgnoreCase));
                    if (entityField.Property.GetValue(entity, null) == null)
                    {
                        if (dataColoumn.AllowDBNull)
                        {
                            dataRow[dataColoumn] = System.DBNull.Value;
                        }
                        else
                        {
                            throw new Exception(dataColoumn.ColumnName + " cannot have null value.");
                        }
                    }
                    else
                    {
                        if (entityField.Property.GetType().IsEnum)
                        {
                            dataRow[dataColoumn] = Convert.ToByte(entityField.Property.GetValue(entity, null));
                        }
                        else
                        {
                            dataRow[dataColoumn] = entityField.Property.GetValue(entity, null);
                        }
                    }
                }
            }
        }
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
    }
