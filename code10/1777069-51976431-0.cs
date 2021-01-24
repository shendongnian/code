    var myResults = from WIG in db.WorkingInterestGroups
                                join In in db.Interests on WIG.Id equals In.WorkingInterestGroupId
                                join Tr in db.Tracts on In.TractId equals Tr.Id
                                where WIG.LeaseId == LeaseID
                                group new { WIG,In,Tr } by new
                                {
                                    WIG.LeaseId,
                                    Tr.Id,
                                    Tr.Name,
                                    Tr.GrossAc,
                                    Tr.County,
                                    Tr.District,
                                    Tr.Legal,
                                    Tr.Source                                
                                } into gcs
                                select new GISTracts
                                {
                                    LeaseID = gcs.Key.LeaseId,
                                    TractID = gcs.Key.Id,
                                    TractName = gcs.Key.Name,
                                    GrossAc = gcs.Key.GrossAc,
                                    County = gcs.Key.County,
                                    Source = gcs.Key.Source,
                                    Legal = gcs.Key.Legal,
                                    Net = gcs.Sum(x=>x.Tr.GrossAcres * x.In.GasExecutive)
                                };
