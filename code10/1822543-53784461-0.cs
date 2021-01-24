        class Program
        {
            
            
            static void Main(string[] args)
            {
                List<PostCode> postCodes = new List<PostCode>() {
                    new PostCode() {postcode = "XYZ 123", premise = 1, connectivity = "HIGH", availability = "TRUE"},
                    new PostCode() {postcode = "XYZ 123", premise = 2, connectivity = "LOW", availability = "TRUE"},
                    new PostCode() {postcode = "XYZ 123", premise = 3, connectivity = "LOW", availability = "FALSE"},
                    new PostCode() {postcode = "ABC 234", premise = 1, connectivity = "HIGH", availability = "FALSE"},
                    new PostCode() {postcode = "ABC 123", premise = 2, connectivity = "HIGH", availability = "FALSE"}
                };
                var results = postCodes.GroupBy(x => x.postcode)
                    .Select(x => x.GroupBy(y => y.premise).Select(z => new { item = z, count = z.Count() }).ToList())
                    .ToList();
      
            }
        }
        public class PostCode
        {
            public string postcode {get; set;}
            public int premise { get; set; }
            public string connectivity { get; set; }
            public string availability { get; set; }
        }
