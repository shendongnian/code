    var predicate = PredicateBuilder.True<Transaction>();  
    predicate = predicate.And(t=>t.Id == transactionId);  
    if (!string.IsNullOrEmpty(department))  
    {  
        predicate = predicate.And(tran => tran.Dept!= "AllDept");  
    }
    var result = _ctx.Transactions.where(predicate);
