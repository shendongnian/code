    var stuff = from l in _db.SqlLinks
                            select new
                                       {
                                           Link = l,
                                           Rating = (int?)(from v in l.SqlLinkVotes
                                                     where v.Tag == tagId
                                                           && v.VoteDate >= since
                                                     select v.Vote).Sum(),
                                           NumberOfVotes = (from v in l.SqlLinkVotes
                                                            where v.Tag == tagId
                                                                  && v.VoteDate >= since
                                                            select v.Vote).Count(),
                                           NumberOfComments = (from v in l.SqlLinkVotes
                                                               where v.Tag == tagId
                                                                     && v.VoteDate >= since
                                                                     && v.Comment != ""
                                                               select v.Vote).Count()
                                       };
