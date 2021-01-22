    public int? Page {
        get {
            Contract.Ensures(Contract.Result<int?>() == null 
                || Contract.Result<int?>() >= 0); 
            return default(int?);
            }
        }
     }
