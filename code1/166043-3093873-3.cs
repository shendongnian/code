    public enum DISTTYPE
            {
                Cash = 1,
                Pay = 2,
                Avail = 3,
                Taken = 4,
                Fnchg = 5,
                Purch = 6,
                Trade = 7,
                Misc = 8,
                Freight = 9,
                Taxes = 10,
                Write = 11,
                Other = 12,
                Gst = 13,
                Wh = 14,
                Unit = 15,
                Round = 16
            }
    
            public enum DOCTYPE
            {
                Invoice = 1,
                [Description("Finance Charge")]
                FinanceCharge = 2,
                [Description("Miscellaneaous Charge")]
                MiscellaneaousCharge = 3,
                Return = 4,
                [Description("Credit Memo")]
                CreditMemo = 5,
                [Description("Manual Checks")]
                ManualChecks = 6
            }
