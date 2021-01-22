    public int? Page {
        get {
            EnsuresNullOrPositive();
            return default(int?)
        }
    }
    [ContractAbbreviator]
    static void EnsuresNullOrPositive(int? x) {
        Contract.Ensures(
            Contract.Result<int?>() == null ||                 
            Contract.Result<int?>() >= 0);
    }
