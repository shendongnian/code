    protected override void Seed(YourDbContext context)
    {
        context.PaymentType.AddOrUpdate(x => x.Id,
            new PaymentType() { Id = 1, Description= "Card" },
            new PaymentType() { Id = 2, Description= "Cash" },
            new PaymentType() { Id = 3, Description= "Cheque" }
            );    
    }
