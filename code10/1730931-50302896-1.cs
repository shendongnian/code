        Store s = // as defined earlier;
        Item i1 = // as defined earlier;
        Item i2 = // as defined earlier;
        s.ItemID.Add(i1);
        s.ItemID.Add(i2);
        using (var session = NhConfig.GetSession())
        {
            var trans = session.BeginTransaction();
            try
            {
                session.SaveOrUpdate(s);
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }
        // Later when you need to query
        using (var session = NhConfig.GetSession())
        {
            Store store = session.QueryOver<Store>().Where(x => x.StoreID == 1).SingleOrDefault();
            foreach (var item in store.ItemID) // store.ItemID.Count == 2.
            {
                Console.WriteLine($"Item - Id: {item.ItemID}. Name: {item.Name}. Store ID: {item.StoreID.StoreID}.");
            }
            /* The above loop will print:
               Item - Id: 1. Name: Item 1. Store ID: 1.
               Item - Id: 2. Name: Item 2. Store ID: 1.
            */
        }
