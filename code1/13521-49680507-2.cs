        public static T WithinTransaction<T>(this IDbConnection cnn, Func<IDbTransaction, T> fn)
        {
            cnn.Open();
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
                finally
                {
                    cnn.Close();
                }
            }
        }
