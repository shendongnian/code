        public void Test()
        {
            Customer c = new Customer() { Username = "TED ÅÄÖ", DeletedTime = DateTime.MaxValue, MyTimeSpan = new TimeSpan(1, 30, 0) };
            CoreObject co = c;
            long id;
            using (IDbConnection db = _dbFactory.Open())
            {
                var typedApi = db.CreateTypedApi(co.GetType());
                id = typedApi.Insert(co, selectIdentity: true);
            };
            using (IDbConnection db = _dbFactory.Open())
            {
                string tableName = co.GetType().GetModelMetadata().ModelName;
                List<Dictionary<string, object>> results = db.Select<Dictionary<string, object>>($"SELECT * FROM {tableName} where id={id}");
                List<CoreObject> coreObjects = results.Map(x => (CoreObject)x.FromObjectDictionary(co.GetType()));
            }
        }
