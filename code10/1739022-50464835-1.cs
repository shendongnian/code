    public void GetByCustomerTransactionId(int id)
    {
         var result = context.CustomerTransaction.Where(x=>x.CustomerTransactionId == id)
         .Include(i=>i.ProductType)
         .Include(i=>i.StatusType);
    }
