     //Customer Current Ledger 
            public static CustomerLedgerViewModel ToModel(this DJBL_tblCustomerCurrentLedger obj)
            {
                return Mapper.Map<DJBL_tblCustomerCurrentLedger, CustomerLedgerViewModel>(obj);
            }
            public static DJBL_tblCustomerCurrentLedger ToEntity(this CustomerLedgerViewModel model)
            {
                return Mapper.Map<CustomerLedgerViewModel, DJBL_tblCustomerCurrentLedger>(model);
            } 
