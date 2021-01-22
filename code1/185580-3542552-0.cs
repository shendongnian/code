    List<TResult> Load<TKey, TResult>(Func<TKey, TResult> select)
    {
            using (Erp.DAL.ErpEntities erpEntityCtx = new Erp.DAL.ErpEntities())
            {
                return erpEntityCtx.Customer.Select(select).ToList<TResult>();
            }
    }
