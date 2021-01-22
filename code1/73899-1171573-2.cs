    public class Referrals
    {
        private List<Referral> refs;
        public class Referrals()
        {
            this.refs = new List<Referral>();
        }
        public Referral Add(string MyURL, string MyKeyword)
        {
           var ref = this.refs.Find(delegate(Referral r) { return r.URL == MyURL; });
           if (ref != null)
           {
               if (ref.Keyword == MyKeyword)
               {
                   ref.IncrementOccurrences();
               }
           }
           else
           {
               ref = new Referral(MyURL, MyKeyword);
               this.refs.Add(ref);
           }
           return ref;
        }
    }
