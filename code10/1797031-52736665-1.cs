            static List<Table1> ViewRecords()
        {
            try
            {
                MongoContext db = new MongoContext();
                IMongoCollection<Table1> = db._database.GetCollection<Table1>("Table1");
                IMongoCollection<Table2> = db._database.GetCollection<Table2>("Table2");
                var r = from t1 in Table1.AsQueryable()
                        join t2 in Table2.AsQueryable() on t1._Id equals t2.UserId
                        select new Table1()
                        {
                            _Id = t1._Id,
                            Name = t1.Name
                        };
                return r.ToList();
            }
            catch (Exception ex) { throw ex; }
        }
