        //This is a shell to create any kind of TVP
        private static void AddTableCore<T>(
            this DynamicParametersTvp dp,
            string tvpTypeName,
            Func<T, SqlDataRecord> valueProjection,
            IEnumerable<T> values,
            string parameterTableName)
        {
            var tvp = values
                .Select(valueProjection)
                .ToList();
            //If you pass a TVP with 0 rows to SQL server it will error, you must pass null instead.
            if (!tvp.Any()) tvp = null;
            dp.Add(new TableValueParameter(parameterTableName, tvpTypeName, tvp));
        }
        //This will create your specific Items TVP
        public static void AddItemsTable(this DynamicParametersTvp dp, IEnumerable<Item> items, string parameterTableName = "Items")
        {
            var columns = new[]
            {
                new SqlMetaData("ItemID", SqlDbType.Int)
                new SqlMetaData("Quantity", SqlDbType.Int)
            };
            var projection = new Func<Item, SqlDataRecord>(item =>
            {
                var record = new SqlDataRecord(columns);
                record.SetInt32(0, item.Id);
                record.SetInt32(1, item.Quantity);
                return record;
            });
            AddTableCore(dp, "Items", projection, items, parameterTableName);
        }
