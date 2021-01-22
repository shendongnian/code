    public List<JobImageAudit> CombineForAuditTrail()
            {
                var result = from a in auditList
                             join ai in imageList
                             on a.ImageID equals ai.ImageID
                             //into ait // note grouping        
                             select new JobImageAudit
                             {
                                 JobID = a.JobID,
                                 ImageID = a.ImageID.Value,
                                 CreatedBy = a.CreatedBy,
                                 CreatedDate = a.CreatedDate,
                                 Comment = a.Comment,
                                 LowResUrl = ai.LowResUrl,
    
                             };
                return result.ToList();
            }
