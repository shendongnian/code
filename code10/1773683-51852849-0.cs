    public class Client
    {
        public async Task<ActionResult<IEnumerable<string>>> GetLinks()
        {
            IEnumerable<string> links = new List<string>() {
                "L1","L2"
            };
            return new ObjectResult(links);
            // Some logic here, 
        }
        public async Task<IEnumerable<string>> GetLinks1()
        {
            IEnumerable<string> links = new List<string>() {
                "L1","L2"
            };
            return links;
            // Some logic here, 
        }
    }
