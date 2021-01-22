    DateTime dTransactionDate = new DateTime();
    if (DateTime.TryParseExact(sTransactionDate, "yyyy",
        CultureInfo.InvariantCulture, DateTimeStyles.None, out dTransactionDate))
    {
        // Happy
    }
    else
    {
        // Sad
    }
