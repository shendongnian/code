    var resultSets = (from k in list
                      select (from b in db.Sites
                              where b.site_title.Contains(k)
                              select b.ToBusiness()).ToList<Business>()).ToList();
     List<Business> all = new List<Business>();
     for (int i = 0; i < resultSets.Count; ++i)
     {
         all.AddRange(resultSets[i]);
     }
