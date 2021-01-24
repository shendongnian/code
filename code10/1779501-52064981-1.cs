    var myList = (from tbl in Context.TableA.AsNoTracking()
                  where duplicateIDs.Contains(tbl.SubmissionNo)
                  select new 
                  { 
                    ID = tbl.ID, 
                    Name = tbl.Name, 
                    SubmissionNo = tbl.SubmissionNo 
                  })
                  .ToList();
