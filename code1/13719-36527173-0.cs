        public List<TEntity> Clone<TEntity>(List<TEntity> o1List) where TEntity : class , new()
        {
            List<TEntity> retList = new List<TEntity>();
            try
            {
                Type sourceType = typeof(TEntity);
                foreach(var o1 in o1List)
                {
                    TEntity o2 = new TEntity();
                    foreach (PropertyInfo propInfo in (sourceType.GetProperties()))
                    {
                        var val = propInfo.GetValue(o1, null);
                        propInfo.SetValue(o2, val);
                    }
                    retList.Add(o2);
                }
                return retList;
            }
            catch
            {
                return retList;
            }
        }
