     var checkIn = iclock_transaction
                                .Where(x => x.punch_state == "0" )
                               // .AsEnumerable()
                                .GroupBy(x=>new { x.emp_code,x.punch_time.Date })
                                // order by descending on the group
                                // and then take the first
                                .Select(grp => grp.OrderBy(x => x.punch_time).First())
                                .ToList();
            //********* Perfectly work with check out   ********
            var checkOut = iclock_transaction
                              .Where(x => x.punch_state == "1")
                             // .AsEnumerable()
                              .GroupBy(x => x.emp_code)
                              // order by descending on the group
                              // and then take the first
                              .Select(grp => grp.OrderByDescending(x => x.punch_time).First())
                              .ToList();
            iclock_transaction = checkIn.Concat(checkOut).ToList();
