    public abstract class SponsorInfo
    {
        public string SponserName { get; set; }
        protected SponsorInfo(string sponserName)
        {
            SponserName = sponserName;
        }
    }
    public class SponsorA : SponsorInfo
    {
        public int ReferenceId { get; set; }
        public string Password { get; set; }
        public SponsorA(string sponserName, int referenceId, string password) 
            : base(sponserName)
        {
            ReferenceId = referenceId;
            Password = password;
        }
    }
    public class SponsorB : SponsorInfo
    {
        public string UserName { get; set; }
        public string Relation { get; set; }
        public string Department { get; set; }
        public SponsorB(string sponsorName, string userName, string relation, string department) 
            : base(sponsorName)
        {
            UserName = userName;
            Relation = relation;
            Department = department;
        }
    }
