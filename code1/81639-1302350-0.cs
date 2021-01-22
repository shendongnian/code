    using (AdventureWorksEntities adv = new AdventureWorksEntities())
    {
         var completeHeader = (from o in adv.SalesOrderHeader.Include("SalesOrderDetail")
                                 where o.DueDate > System.DateTime.Now
                                 select o).First();
         completeHeader.ShipDate = System.DateTime.Now;
         adv.AcceptAllChanges();
         var details = completeHeader.SalesOrderDetail.Where(x => x.UnitPrice > 10.0m);
         foreach (SalesOrderDetail d in details)
         {
              d.UnitPriceDiscount += 5.0m;     
         }
              adv.SaveChanges();
    }
