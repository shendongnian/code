    public List<account> GetAccountsByName(string name, bool usePaging, int offset = 0, int take = 0) {
       var query = GetMyQuery();
       query = query.Where(x => x.Name == name);
       query = query.OrderBy(x => x.Name);
       if(usePaging) {
          query = query.Take(take).Skip(offset);
       }
       query = PrepareSelectForAccount(query);
       return query.ToList();    .
    }
    
    public IQueryable<account> GetMyQuery(){
     return ctx.account.AsQueryable();
    }
    public IQueryable<account> PrepareSelectForAccount(IQueryAble<account> query){
         return query.Select(select new AccountInfo()
                    {
                        Name = account.Name,
                        Mid = account.MemberID,
                        Date = account.Date,
                        Address = account.Address,
    
                    }
          );
    }
