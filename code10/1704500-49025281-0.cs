    public List<ContestantRating.Core.ViewModel.ContestantRatingVM> GetContestantRatingList()
    {
      var tempArray = (from c in db.Contestants where C.IsActive==true
                       join cr in db.ContestantRatings on C.Id equals CR.ContestantId 
                       select new { C = c, CR = cr }).ToArray();
      var contestantRatingList = from x in tempArray select new ContestantRatingVM
                                    {
                                        ContestantId  = Convert.ToInt32(x.CR.ContestantId),
                                        FirstName = x.C.FirstName,
                                        // ...
                                    }).ToList().OrderByDescending(x => x.RatingId);
      return contestantRatingList.ToList();
    }
