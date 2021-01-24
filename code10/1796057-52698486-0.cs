    private static void BulkInsertAllAndReturnIds<T>(BulkInsertionCollectionMetadata<T> items, string schema,
        string tableName,
        IList<ColumnMapping> properties, SqlConnection connection, int? batchSize)
    {
        if (items.Count == 0) return;
        long dummyValue = -1000 - items.Count;
        //set dummy IDs
        foreach (var item in items)
        {
            ((IHasPrimaryKey)item).PrimaryKey = dummyValue;
            dummyValue++;
        }
        try
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
 
            //create dummy table.
            using (var tempTable = new TempTable(connection, tableName, schema))
            {
                var createTempTableSql = $"Select * Into {tempTable.TableName} From {tableName} Where 1 = 2";
                using (var command = new SqlCommand(createTempTableSql, connection))
                {
                    command.ExecuteNonQuery();
                }
 
                //bulk insert to temp table.
                BulkInsertAll(items, schema, tempTable.TableName, properties, connection, batchSize,
                    SqlBulkCopyOptions.KeepNulls | SqlBulkCopyOptions.KeepIdentity);
 
                //note: IsPrimaryKey is not populated in InsertAll 
                // https://github.com/MikaelEliasson/EntityFramework.Utilities/blob/a5abc50b7367d64ca541b6e7e2e6018a500b6d8d/EntityFramework.Utilities/EntityFramework.Utilities/EFBatchOperation.cs#L129
 
                string primaryKeyNameOnObject = ((IHasPrimaryKey)items.First()).PrimaryKeyPropertyName;
                var primaryKey = properties.Single(c => c.NameOnObject == primaryKeyNameOnObject);
                var otherColumns = properties.Where(p => p != primaryKey);
                var allValueColumns = String.Join(", ", otherColumns.Select(c => "[" + c.NameInDatabase + "]"));
 
                //insert to real table and get new IDs.
                //this guarantees the record IDs are generated in the right order.
                var migrateAndReturnIds =
                    $@"
                    insert into {tableName} ({allValueColumns})
                    OUTPUT inserted.{primaryKey.NameInDatabase}
                    select {allValueColumns} from {tempTable.TableName} temp
                    order by temp.{primaryKey.NameInDatabase}
                    ";
 
                var newlyGeneratedIds = new List<long>(items.Count);
                using (var migrateDataCommand = new SqlCommand(migrateAndReturnIds, connection)
                {
                    CommandTimeout = 0
                })
                using (var recordIdReader = migrateDataCommand.ExecuteReader())
                {
                    while (recordIdReader.Read())
                    {
                        var newId = recordIdReader.GetInt64(0);
                        newlyGeneratedIds.Add(newId);
                    }
                }
                //set IDs on entities.
                if (newlyGeneratedIds.Count != items.Count)
                {
                    throw new MissingPrimaryKeyException("There are fewer generated record IDs than the " +
                                                            "number of items inserted to the database.");
                }
                //the order of the IDs is not guaranteed, but the values will be generated in the same as the order values in `items`
                newlyGeneratedIds.Sort();
                for (int i = 0; i < newlyGeneratedIds.Count; i++)
                {
                    ((IHasPrimaryKey)items[i]).PrimaryKey = newlyGeneratedIds[i];
                }
            }
        }
        finally
        {
            //make sure the ID is 0 if the row wasn't inserted.
            foreach (var item in items)
            {
                var entity = (IHasPrimaryKey)item;
                if (entity.PrimaryKey < 0) entity.PrimaryKey = 0;
            }
        }
    }
