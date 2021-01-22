    using (ISession session = NHibernateHelper.OpenStatelessSession(NHibernateHelper.Databases.CarrierCDR))
      using (session.BeginTransaction(IsolationLevel.ReadUncommitted))
      {
       lCdrs = (from verizon in session.Linq<Domain.Verizon>()
                 where verizon.Research == true
                 && verizon.ReferenceTable == null
                 orderby verizon.CallBillingDate descending 
                  select verizon).ToList();
    }
