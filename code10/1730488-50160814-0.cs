    void GetData2(Expression<Func<CT2, bool>> selection) {
        var baseQuery = from ct1 in db.CustomerTransaction
                        join ct2 in db.CustomerTransaction on ct1.MasterTransactionID equals ct2.RelatedTransactionID
                        select new CT2 { ct1 = ct1, ct2 = ct2 };
        var query = baseQuery.Where(selection).Dump();
    }
    Expression<Func<CT2, bool>> query2 =
           r => r.ct1.CustomerID != r.ct2.CustomerID;
    GetData2(query2);
