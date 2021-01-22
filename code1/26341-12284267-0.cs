        private static readonly PropertyInfo ConnectionInfo = typeof(SqlConnection).GetProperty("InnerConnection", BindingFlags.NonPublic | BindingFlags.Instance);
        private static SqlTransaction GetTransaction(IDbConnection conn) {
            var internalConn = ConnectionInfo.GetValue(conn, null);
            var currentTransactionProperty = internalConn.GetType().GetProperty("CurrentTransaction", BindingFlags.NonPublic | BindingFlags.Instance);
            var currentTransaction = currentTransactionProperty.GetValue(internalConn, null);
            var realTransactionProperty = currentTransaction.GetType().GetProperty("Parent", BindingFlags.NonPublic | BindingFlags.Instance);
            var realTransaction = realTransactionProperty.GetValue(currentTransaction, null);
            return (SqlTransaction) realTransaction;
        }
