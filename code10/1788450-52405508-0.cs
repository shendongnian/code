    public string FormattedtTransactionTime
    {
        get
        {
            DateTime dt;
            if (!string.IsNullOrEmpty(TransactionTime)
                && DateTime.TryParseExact(TransactionTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                return dt.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            return null;
        }
    }
