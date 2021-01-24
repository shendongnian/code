     var candidate = (from curCandidate in db.Candidates.Include("Category").Include("PoliticalParty").Include("Office").Include("Websites").Include("Websites.WebsiteType")
                                    where curCandidate.Id == id
                                    select new CandidateDetailsDTO
                                    {
                                        Id = curCandidate.Id,
                                        LastName = curCandidate.LastName,
                                        FirstName = curCandidate.FirstName,
                                        Bio = curCandidate.Bio,
                                        Address = curCandidate.Address,
                                        CategoryName = curCandidate.Category.CategoryName,
                                        PoliticalParty = curCandidate.PoliticalParty.PartyName,
                                        Office = curCandidate.Office.OfficeName,
                                        Websites = curCandidate.Candidate.Websites
                                    }).FirstOrDefault();
