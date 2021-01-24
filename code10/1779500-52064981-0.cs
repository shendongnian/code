    var duplicates = (from tbl in Context.TableA.AsNoTracking()
                      group tbl by tbl.SubmissionNo into grp
                      select new { count = grp.Count(), submissionNo = grp.Key})
                     .Where(x => x.count > 1)
                     .OrderBy(y => y.submissionNo)
                     .ToList();
    var duplicateIds = duplicates.Select(x => x.submissionNo).ToList();
