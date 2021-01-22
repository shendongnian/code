    class Program
        {
            static AccountContextDataContext aContext = new AccountContextDataContext(@"DATA SOURCE");
            static LoanContextDataContext lContext = new LoanContextDataContext(@"DATA SOURCE");
    
            static void Main()
            {
    
                var query = from a in aContext.ACCOUNTs
                            join app in aContext.APPLICATIONs on a.GUID_ACCOUNT_ID equals app.GUID_ACCOUNT
                            select GetLoans(app.GUID_APPLICATION);
    
                IEnumerable<LOAN> loan = query.First();
                foreach (LOAN enumerable in loan)
                {
                    Console.WriteLine(enumerable.GUID_LOAN);
                }
    
                Console.ReadLine();
            }
    
            private static IEnumerable<LOAN> GetLoans(Guid applicationGuid)
            {
                return (from l in lContext.LOANs where l.GUID_APPLICATION == applicationGuid select l).AsQueryable();
            }
        }
