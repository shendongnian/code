    public static List<CardTransactionHistoryWM> Merge(
        List<UserPaymentAccountHistoryLog> userPaymentAccountHistoryLogs,
        List<UserPaymentHistoryLog> userPaymentHistoryLogs)
    {
        var results = new List<CardTransactionHistoryWM>();
        foreach (var upahl in userPaymentAccountHistoryLogs)
        {
            var match = results.SingleOrDefault(cthwm => cthwm.LogHistory == upahl.LogHistory);
            if (match == null)
            {
                results.Add(CardTransactionHistoryWM.Parse(upahl));
            }
            else
            {
                match.MergeWith(upahl);
            }
        }
        foreach (var uphl in userPaymentHistoryLogs)
        {
            var match = results.SingleOrDefault(cthwm => cthwm.LogHistory == uphl.LogHistory);
            if (match == null)
            {
                results.Add(CardTransactionHistoryWM.Parse(uphl));
            }
            else
            {
                match.MergeWith(uphl);
            }
        }
        return results;
    }
