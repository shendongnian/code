        class Program
    {
        static AccountContextDataContext aContext = new AccountContextDataContext(@"Data Source=ITDBTCL\TCLINT;Initial Catalog=Elastic;Integrated Security=True");
        static LoanContextDataContext lContext = new LoanContextDataContext(@"Data Source=ITDBTCL\TCLINT;Initial Catalog=Elastic;Integrated Security=True");
    
        static void Main()
        {
    
            var query = from a in aContext.ACCOUNTs
                        join app in aContext.APPLICATIONs on a.GUID_ACCOUNT_ID equals app.GUID_ACCOUNT
                        where app.GUID_APPLICATION.ToString() == "24551D72-D4C2-428B-84BA-5837A25D8CF6"
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
