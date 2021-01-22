    var itemColl = from p in db.A
                   where p.CardID == "some GUID"
                   select new {
                       p.CardID,
                       p.secondCol,
                       p.ThirdCol,
                       Items = db.B.Where(b=>b.CardID==p.CardID)
                          .Select(b=>b.ItemNo)
                   }
