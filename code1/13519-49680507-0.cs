        public static T WithinTransaction<T>(this IDbConnection cnn, Func<IDbTransaction, T> fn)
        {
            using (var transaction = cnn.BeginTransaction())
            {
                try
                {
                    T res = fn(transaction);
                    transaction.Commit();
                    return res;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
