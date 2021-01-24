    return (from t in context.TimeCaptures
                join jc in context.JobCards on t.JobCardID equals jc.ID into jcSub
                from jc in jcSub.DefaultIfEmpty()
                join cu in context.Companies on jc.CustomerID equals cu.ID into cuSub
                from tg in cuSub.DefaultIfEmpty()
                where (t.CreatedBy == actor)
                //orderby t.Date descending
                select new TimeReviewDataModel
                {
                    ID = t.ID,
                    CustomerName = tg.Name,
                    Date = t.Date,
                    StartTime = t.StartTime,
                    EndTime = t.EndTime,
                    Description = t.Description,
                    Category = t.Category,
                    JobCardID = t.JobCardID,
                    VsoTask = t.VsoTaskID,
                    IsBillable = (bool)t.Billable
                })
                .OrderByDescending(e=>e.Date).ThenByDescending(e=>eStartTime);
