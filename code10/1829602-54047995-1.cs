    public class DataRowPredicate
        : IPredicate<DataRow>
    {
        private readonly string _keyColumn;
        private readonly string _keyValue;
        public DataRowPredicate(string keyColumn, string keyValue)
        {
            _keyColumn=keyColumn;
            _keyValue=keyValue;
        }
        public bool Condition(DataRow r)
        {
            return string.Equals(SafeTrim(r[_keyColumn]), _keyValue, StringComparison.CurrentCultureIgnoreCase); 
        }
    }
