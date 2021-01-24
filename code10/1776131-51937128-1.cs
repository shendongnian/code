    public class TransactionModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? SysDate { get; set; }
        public List<TransactionItemModel> Trade { get; set; }
        public TransactionModel(DataRow row)
        {
            if(row == null)
                throw new ArgumentNullException(nameof(row));
            Id = row.Field<int>("Id");
            Description = row.Field<string>("Description");
            SysDate = row.Field<DateTime?>("SysDate");
            Trade = new List<TransactionItemModel>();
        }
    }
    public class TransactionItemModel
    {
        public int ItemId { get; set; }
        public int TransactionId { get; set; }
        public string ItemDescription { get; set; }
        public decimal? ItemNetAmount { get; set; }
        public TransactionItemModel(DataRow row)
        {
            if(row == null)
                throw new ArgumentNullException(nameof(row));
            ItemId = row.Field<int>("Id");
            TransactionId = row.Field<int>("TransactionId");
            ItemDescription = row.Field<string>("ItemDescription");
            ItemNetAmount = row.Field<decimal?>("ItemNetAmount");
        }
    }
    public static class Program
    {
        private static void Main()
        {
            DataTable tranResultSet = MethodToReturnResultsFromTranQuery();
            DataTable itemResultSet = MethodToReturnResultsFromItemQuery();
            var transactions = tranResultSet.AsEnumerable()
                                            .Select(r => new TransactionModel(r));
            foreach(TransactionModel transaction in transactions)
            {
                var items = itemResultSet.AsEnumerable()
                                         .Where(r => r.Field<int>("TransactionId") == transaction.Id)
                                         .Select(r => new TransactionItemModel(r));
                transaction.Trade.AddRange(items);
            }
        }
    }
