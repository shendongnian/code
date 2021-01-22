    public static class AllegedPerpetratorRepository
    {
        public static IEnumerable<string> GetByCaseID(
            this IQueryable<AllegedPerpetrator> source,
            int caseID)
        {
            return (from s in source where s.CaseID.Equals(caseID) select s.LastName); 
        }
    }
