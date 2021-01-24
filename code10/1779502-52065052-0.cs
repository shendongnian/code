    var myList  = from tbl in Context.TableA.AsNoTracking()
                  group tbl by tbl.SubmissionNo into grp
                  where grp.Count() > 1
                  from item in grp
                  select new
                  { 
                      count = grp.Count(),
                      submissionNo = grp.Key,
                      item.Name,
                  );
