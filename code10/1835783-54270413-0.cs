    string[] restrictions = new string[] { null, null, tableName };
    using (DataTable columns = conn.GetSchema("Columns", restrictions)) {
        int nameIndex = columns.Columns.IndexOf("COLUMN_NAME");
        int ordinalPosIndex = columns.Columns.IndexOf("ORDINAL_POSITION");
        int isNullableIndex = columns.Columns.IndexOf("IS_NULLABLE");
        int maxLengthIndex = columns.Columns.IndexOf("CHARACTER_MAXIMUM_LENGTH");
        int dataTypeIndex = columns.Columns.IndexOf("DATA_TYPE");
        int isPrimaryKeyIndex = columns.Columns.IndexOf("PRIMARY_KEY");
        int hasDefaultIndex = columns.Columns.IndexOf("COLUMN_HASDEFAULT");
        int defaultValueIndex = columns.Columns.IndexOf("COLUMN_DEFAULT");
        foreach (DataRow row in columns.Rows) {
            var col = new TableColumn {
                ColumnName = (string)row[nameIndex]
            };
            try {
                col.ColumnNameForMapping = prepareColumnNameForMapping(col.ColumnName);
            } catch (Exception ex) {
                throw new UnimatrixExecutionException("Error in delegate 'prepareColumnNameForMapping'", ex);
            }
            col.ColumnOrdinalPosition = (int)row[ordinalPosIndex];
            col.ColumnAllowsDBNull = (bool)row[isNullableIndex];
            col.ColumnMaxLength = (int)row[maxLengthIndex];
            string explicitDataType = ((string)row[dataTypeIndex]).ToLowerInvariant();
            col.ColumnDbType = GetColumnDbType(explicitDataType);
            col.ColumnIsPrimaryKey = (bool)row[isPrimaryKeyIndex];
            col.ColumnIsIdentity = explicitDataType == "integer" && col.ColumnIsPrimaryKey;
            col.ColumnIsReadOnly = col.ColumnIsIdentity;
            if ((bool)row[hasDefaultIndex]) {
                col.ColumnDefaultValue = GetDefaultValue(col.ColumnDbType, (string)row[defaultValueIndex]);
                if (col.ColumnDefaultValue == null) { // Default value could not be determined. Probably expression.
                    col.AutoAction = ColumnAction.RetrieveAfterInsert;
                }
            }
            tableSchema.ColumnSchema.Add(col);
        }
    }
