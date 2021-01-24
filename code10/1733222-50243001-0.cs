        public static void Main(string[] args)
        {
            XmlDocument someDoc = new XmlDocument();
            someDoc.LoadXml(@"<bananas>
                            <banana tasty='yes'></banana>
                            <banana tasty='very'></banana>
                            <banana tasty='amazing'></banana>
                            <banana tasty='mind-blowing'></banana>
                            <banana tasty='disgusting'></banana>
                          </bananas>");
            XmlNodeList bananaNodeList = someDoc.SelectNodes("//banana");
            var allBananas = bananaNodeList.Cast<XmlNode>().AsQueryable();
            
            eatSomeBananas(allBananas, 2);
        }
        public static void eatSomeBananas(IQueryable<XmlNode> subBananas, int numberOfBananas)
        {
            var queryable = subBananas.Cast<XmlNode>().AsQueryable();
            var bananasToEat = (from a in queryable
                    select a).Take(numberOfBananas);
            var remainingBananas = (from a in queryable
                select a).Skip(numberOfBananas);
            
            
            Console.WriteLine(string.Format("Bananas to eat: {0}", bananasToEat.Count()));
            Console.WriteLine(string.Format("Remaining bananas: {0}", remainingBananas.Count()));
            if (!bananasToEat.Any())
                Console.WriteLine("Error! Did not work (not enough bananas!)");
            else 
                eatSomeBananas(remainingBananas, numberOfBananas);
        }
