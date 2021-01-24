    public struct CashAmount
    {
        public int leftNumberExact, decimalNumberExact;
    
        public string CashAmountExact
        {
             get:
             {
                 return leftNumberExact + "." + decimalNumberExact;
             }
        }
    
        public decimal CashAmountApprox
        {
            get:
            {
                return decimal.Parse(CashAmountExact);
            }
        }
    }
