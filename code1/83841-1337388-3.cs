    public abstract class RecruiterBase<T>
        {
            // Constructors declared here
    
            public abstract IQueryable<CandidateBase> GetCandidates();
        }
        
        public abstract class CandidateBase
        {
            // Constructors declared here
        }
        
   
        public class CandidateA : CandidateBase
        {
    
        }
    
        public class RecruiterA : RecruiterBase<RecruiterA>
        {
            // Constructors declared here
    
            // ----HERE IS WHERE I AM BREAKING DOWN----
            public override IQueryable<CandidateBase> GetCandidates()
            {
                return Enumerable.Range(0, 5).Select(x => new CandidateA()).Cast<CandidateBase>().AsQueryable();
            }
        }
