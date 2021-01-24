    var query = (from t1 in lst
                         join t2 in (from b in lst
                                     group b by b.REQUEST_ID into grp
                                     select new
                                     {
                                         EndTime = (from g1 in grp select g1.EXECUTION_DTTM).Max(),
                                         REQUEST_ID = grp.Key,
                                         Transactions = grp.Count(),
                                         Success = ((from g2 in grp select g2.ITEM_STATUS_CD).Count(x => x == 0)) * 100 / grp.Count(),
                                         Warning = ((from g3 in grp select g3.ITEM_STATUS_CD).Count(x => x == 1)) * 100 / grp.Count(),
                                         Error = ((from g4 in grp select g4.ITEM_STATUS_CD).Count(x => x > 1)) * 100 / grp.Count(),
                                     }).Take(100).OrderByDescending(x => x.REQUEST_ID)
                         on new { RID = t1.REQUEST_ID, EXDT = t1.EXECUTION_DTTM } equals new { RID = t2.REQUEST_ID, EXDT = t2.EndTime }
                         select new
                         {
                             t1.REQUEST_ID,
                             t2.Transactions,
                             t2.EndTime,
                             t2.Success,
                             t2.Warning,
                             t2.Error
                         }).Distinct().ToList();
