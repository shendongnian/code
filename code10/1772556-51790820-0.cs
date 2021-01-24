    public class CardTransactionHistoryWM
    {
        public bool ActionType { get; set; }
        public bool TransactionType { get; set; }
        public DateTime LogHistory { get; set; }
        public string LogDetail { get; set; }
        public OrderWM Order { get; set; }
        public void MergeWith(UserPaymentHistoryLog uphl)
        {
            if (LogHistory != uphl.LogHistory)
                throw new InvalidOperationException("Cannot merge if LogHistory dates don't match");
            TransactionType = uphl.TransactionType;
            LogDetail = string.Concat(LogDetail, uphl.LogDetail);
        }
        public void MergeWith(UserPaymentAccountHistoryLog upahl)
        {
            if (LogHistory != upahl.LogHistory)
                throw new InvalidOperationException("Cannot merge if LogHistory dates don't match");
            ActionType = upahl.ActionType;
            LogDetail = string.Concat(LogDetail, upahl.LogDetail);
        }
        public static CardTransactionHistoryWM Parse(UserPaymentHistoryLog source)
        {
            return new CardTransactionHistoryWM
            {
                TransactionType = source.TransactionType,
                LogHistory = source.LogHistory,
                LogDetail = source.LogDetail
            };
        }
        public static CardTransactionHistoryWM Parse(UserPaymentAccountHistoryLog source)
        {
            return new CardTransactionHistoryWM
            {
                ActionType = source.ActionType,
                LogHistory = source.LogHistory,
                LogDetail = source.LogDetail
            };
        }
    }
