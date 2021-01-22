    public class SanitizingDataHelper : IDataHelper
    {
        private IDataHelper helper;
        public SanitizingDataHelper(IDataHelper helper)
        {
            this.helper = helper;
        }
        public void ExecuteNotQuery(string sql)
        {
            sql = EscapeHarmfulSql(sql);
            helper.ExecuteNonQuery(sql);
        }
        private string EscapeHarmfulSql(string sql)
        {
            ...
        }
    }
