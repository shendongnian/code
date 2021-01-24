        public T[] ActionContext<T>(sql)
        {
            using (var db = new ActionContext())
            {
                return  db.Database.SqlQuery<T>(sql).ToArray();
            }
        }
