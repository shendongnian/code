        public class tablea
        {
            public int AID { get; set; }
            public string Field { get; set; }
        }
        public class tableb
        {
            public int BID { get; set; }
            public string Value { get; set; }
        }
        public class tableab
        {
            public int ProfileID { get; set; }
            public int AID { get; set; }
            public string Field { get; set; }
            public int BID { get; set; }
            public string Value { get; set; }
        }
        public class result
        {
            public int? profileid { get; set; }
            public int? aid { get; set; }
            public string field { get; set; }
            public string bid { get; set; }
            public string value { get; set; }
        }
        [Test]
        public void TestQuery()
        {
            var tablea = new List<tablea>();
            var tableb = new List<tableb>();
            var tableab = new List<tableab>();
            tablea.Add(new tablea{AID = 1,Field = "OneField"});
            tablea.Add(new tablea{AID = 2,Field = "TwoField"});
            tablea.Add(new tablea{AID = 3,Field = "ThreeField"});
            tableb.Add(new tableb{BID = 1,Value = "OneValue"});
            tableb.Add(new tableb{BID = 2,Value = "TwoValue"});
            tableb.Add(new tableb{BID = 3,Value = "ThreeValue"});
            tableab.Add(new tableab{AID = 1,BID=1,ProfileID = 1});
            tableab.Add(new tableab{AID = 2,BID=3,ProfileID = 1});
            var profileId = 1;
            var q1 = (from a in tablea
                      let bid = (from ab in tableab where ab.ProfileID == profileId && ab.AID == a.AID select ab.BID).FirstOrDefault()
                      let value = (from ab in tableab where ab.ProfileID == profileId && ab.AID == a.AID && ab.BID == bid select ab.Value).FirstOrDefault()
                    select new result
                                {
                                    profileid = profileId,
                                    aid = a.AID,
                                    field = a.Field,
                                    bid = (bid == 0 ? "null" : bid.ToString()),
                                    value = value ?? "null"
                               }).ToList();
        }
