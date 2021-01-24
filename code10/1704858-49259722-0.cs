    var p = boxes.GroupBy(x => x.ID).Where(grp => grp.Key != -1)
                .Select(grp => new
                {
                    ID = grp.Key,
                    ItemCount = grp.Count(),
                    DateUsed = grp.Max(x => x.DateUsed)
                });
    var q = from x in tracker
            join y in p on x.ID equals y.ID
            join z in boxes on y.ID equals z.ID
            join a in headers on z.PickID equals a.PickID
            select new
            {
                y.ID,
                y.ItemCount,
                DateUser = y.DateUsed,
                a.CustNum,
                a.OrdNum
            };
