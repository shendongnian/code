            var qry = from ee in
                           (from e1 in list1
                            join e2 in list2 on e1.Id equals e2.Id into gj
                            from e in gj.DefaultIfEmpty()
                            select new { 
                                e1.Id,
                                MainHourBy = e1.HourBy,
                                SecondHourBy = (e == null ? 0 : e.HourBy)
                            })
                       where ee.SecondHourBy < ee.MainHourBy
                       group ee by ee.Id into g
                       select new MyClass
                       {
                           Id = g.Key,
                           HourBy = g.First().MainHourBy - g.Sum(el => el.SecondHourBy)
                       };
