    public static T GetByID(int id)
        {
            Type type = typeof(T);
            //get table name
            var att = type.GetCustomAttributes(typeof(TableAttribute), false).FirstOrDefault();
            string tablename = att == null ? "" : ((TableAttribute)att).Name;
            //make a query
            if (string.IsNullOrEmpty(tablename))
                return null;
            else
            {
                string query = string.Format("Select * from {0} where {1} = {2}", new object[] { tablename, "ID", id });
                //and execute
                return dbcontext.ExecuteQuery<T>(query).FirstOrDefault();
            }
        }
