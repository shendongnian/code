        public string DisplayValue
        {
            get {
                 if (Perm)
                 {
                   return HiddenBankAcc;
                }
                else
                {
                   return FullBankAcc;
                }
           }
       }
