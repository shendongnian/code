    using (AquaparkDBDataContext db = new AquaparkDBDataContext())
      {
          PriceList pr = new PriceList
          {
              entry = "pobrane",
              price = 0
          };
          db.tbl_PriceLists.InsertOnSubmit(new tbl_PriceLists{
                 entry = pr.entry,
                 price = pr.price
          });                
          db.SubmitChanges();
      }
