    var changes = (from dr1 in dtItemSales.AsEnumerable()
                   from dr2 in dtItemStock.AsEnumerable()
                   where dr1.Field<string>("ItemCode") == dr2.Field<string>("ItemCode")
                   let sum = dtItemSales.AsEnumerable().Where(x => x.Field<string>("ItemCode") == dr2.Field<string>("ItemCode")).Sum(dr => dr.Field<int>("Quantity"))
                   select new
                   {
                       Name = dr2.Field<string>("ItemCode"),
                       Remarks = dr2.Field<int>("Qty") - sum
                   }).GroupBy(x => x.Name).Select(x => x.First()).ToList();
    
