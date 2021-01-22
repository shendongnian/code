        //Set up some classes to use as holding containers for our test data
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
            public int profileid { get; set; }
            public int aid { get; set; }
            public string field { get; set; }
            public string bid { get; set; }
            public string value { get; set; }
        }
        //Create a nUnit test function
        [Test]
        public void TestQuery()
        {
            //Instantiate some holding containers
            var tablea = new List<tablea>();
            var tableb = new List<tableb>();
            var tableab = new List<tableab>();
            //Load up our holding container with some test data
            tablea.Add(new tablea{AID = 1,Field = "OneField"});
            tablea.Add(new tablea{AID = 2,Field = "TwoField"});
            tablea.Add(new tablea{AID = 3,Field = "ThreeField"});
            tableb.Add(new tableb{BID = 1,Value = "OneValue"});
            tableb.Add(new tableb{BID = 2,Value = "TwoValue"});
            tableb.Add(new tableb{BID = 3,Value = "ThreeValue"});
            tableab.Add(new tableab{AID = 1,BID=1,ProfileID = 1});
            tableab.Add(new tableab{AID = 2,BID=3,ProfileID = 1});
            //Run our query
            var queryResult = (from a in tablea
                     join ab in tableab on a.AID equals ab.AID into g
                     from ab in g.DefaultIfEmpty(new tableab{ProfileID = -1,AID = -1,BID =-1,Field = "",Value = ""})
                     where ab.ProfileID == 1 || ab.ProfileID == -1
                     let bid = (from b in tableb where b.BID == ab.BID select b.BID.ToString()).FirstOrDefault()
                     let value = (from b in tableb where b.BID == ab.BID select b.Value).FirstOrDefault()
                     select new
                                {
                                    profileid = ab.ProfileID,
                                    aid = a.AID,
                                    field = a.Field,
                                    bid = bid,
                                    value = value
                               }).ToList();            
             //At this point queryResult should contain the result of the query.
        }
