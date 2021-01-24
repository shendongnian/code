    var myList  = from tbl in Context.TableA.AsNoTracking()
                  group tbl by tbl.SubmissionNo into grp
                  let count = grp.Count()
                  where count > 1
                  from item in grp
                  select new
                  { 
                      count = count,
                      submissionNo = grp.Key,
                      item.Name,
                  );
