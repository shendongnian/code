        foreach (var item in anchorTables)
        {
            // Use adapter builder to generate T-SQL for querying change tracking data and CRUD
            SqlSyncAdapterBuilder builder = new SqlSyncAdapterBuilder();
            builder.Connection = new SqlConnection(this.connectionStringFactory.ConnectionString);
            builder.ChangeTrackingType = ChangeTrackingType.SqlServerChangeTracking;
            builder.SyncDirection = SyncDirection.Bidirectional;
            builder.TableName = item.TableName;
            // Get sync adapters from builder
            SyncAdapter clientAdapter = builder.ToSyncAdapter();
            clientAdapter.TableName = item.TableName;
            this.clientSyncProvider.SyncAdapters.Add(clientAdapter);
        }
