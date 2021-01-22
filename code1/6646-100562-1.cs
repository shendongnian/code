    interface IDBClass<T> where T:IDbCommand
    {
        void Test(T cmd);
    }
    class DBClass:IDBClass<SqlCommand>
    {
        public void Test(SqlCommand cmd)
        {
        }
    }
