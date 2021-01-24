    public IQueryable<AccountInfo> FooLinq(DbEntities ctx, int id)
    {
            return
                    from account in ctx.account                        
                    orderby account.date descending
                    select new AccountInfo()
                    {
                        Name = account.Name,
                        Mid = account.MemberID,
                        Date = account.Date,
                        Address = account.Address,
    
                    };
    }
    public List<IncomingViolations> Foo1(int id)
    {
        using(var ctx = new dbEntities())
        {
            //Linq query FooLinq() where Name == "Bob"
            return FooLinq(ctx).Where(v => v.Name == "Bob").ToList();
        }
    }
