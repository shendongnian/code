    //Join
    public static IQueryable<IContract> AllContracts(this IQueryable<IAccount> accounts, ISession s ) {
              return from a in accounts
                     from contract in s.Query<IContract()
                     where (a.Id == contract.AccountId)
                     select contract;
        }
    //Where
    public static IQueryable<IContract> Active(this IQueryable<IContract> contracts) {
              return from contract in contracts
                     where (contract.Active == true)
                     select contract;
        }
