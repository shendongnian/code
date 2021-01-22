    public interface IQueryItem
    {
        public String GenerateSQL();
    }
    public class AndQueryItem : IQueryItem
    {
        private IQueryItem _FirstItem;
        private IQueryItem _SecondItem;
        // Properties and the like
        public String GenerateSQL()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_FirstItem.GenerateSQL());
            builder.Append(" AND ");
            builder.Append(_SecondItem.GenerateSQL());
            
            return builder.ToString();
        }
    }
