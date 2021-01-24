    static void Main(string[] args)
    {
        var claims = new List<Claim>();
        claims.Add(new Claim { Balance = 100, Tags = new List<string> { "Blah", "Blah Blah" } });
        claims.Add(new Claim { Balance = 500, Tags = new List<string> { "Dummy Tag", "Dummy tag 1" } });
    
        // tags to be searched for
        var tags = new List<string> { "New", "Blah" };
        var parameters = new List<object>();
        parameters.Add(tags);
    
        var query = claims.AsQueryable().Where("Tags.Any(@0.Contains(outerIt)) AND Balance > 100", parameters.ToArray());
    }
    public class Claim
    {
        public decimal? Balance { get; set; }
        public List<string> Tags { get; set; }
    }
