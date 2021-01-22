    public class Referral
    {
        public Guid id { get; private set; } // "uniquify"
        public int ReferringId { get; set; }
        public string ReferrerText { get; set; }
        public string ReferrerDescription { get; set; }
        private Referral()
        {
           id = new Guid();
        }
        private Referral(string Text, string Description, int ReferringId) : this()
        {
            this.ReferrerText = Text;
            this.ReferrerDescription = Description;
            this.ReferringId = ReferringId;
        }
        public static IEnumerable<Referral> GetReferrals(string fileName) 
        {
            using (var rdr = new StreamReader(fileName))
            {
                var next = new Referrer();
        
                int state = 0;
                string line;
                while ( (line = rdr.ReadLine() ) != null)
                {
                    switch (state)
                    {
                        case 0:
                            next.ReferrerText = line;
                            state = 1;
                            break;
                        case 1:
                            next.ReferrerDescription = line;
                            state = 2;
                            break;
                        case 2:
                            next.ReferringId = int.Parse(line);
                            yield return next;
                            next = new Referral();
                            state = 0;
                            break;
                    }
                }                
            }
        }
    }
