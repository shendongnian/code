    var recommend1 = db.Recommendation.Where(c => c.Comments != "" || c.Comments != null)
                                      .Where(c => c.Visit.ClinicId == 5)
                                      .Select(c => c.VisitId)
                                      .ToList();
    // is not the same as
    WHERE(dbo.Visit.ClinicId = '5') 
       AND(dbo.Recommendation.Comments = '') OR (dbo.Recommendation.Comments IS NULL)
    
