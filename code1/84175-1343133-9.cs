    public abstract class CandidateBase
        {
            public int CandidateId { get; set; }
            public string LastName { get; set;}
            public string FirstName { get; set;}
            public string RecruiterId { get; set; }
    
            //the rest of your logic
        }
    
    public class  RecruiterBase
        {
            // Constructors declared here
    
            // ----HERE IS WHERE I AM BREAKING DOWN----
            public IQueryable<T> GetCandidates<T>() where T:CandidateBase, new()
            {
    
                DataClasses1DataContext db = new DataClasses1DataContext();
                return (from candidates in db.Candidates
                        where candidates.RecruiterId == this.RecruiterId
                        select new T()
                        { 
                            CandidateId = candidates.CandidateId,
                            LastName = candidates.LastName,
                            FirstName = candidates.FirstName,
                            RecruiterId = candidates.RecruiterId
                        }
                        )
                                 
            }
        }
