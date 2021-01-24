        public static XElement GetTransaction(XDocument xDoc)
        {
            return xDoc.Descendants("transaction").FirstOrDefault();
        }
        public static Transaction TransactionFromXML(XElement transactionXElement)
        {
            string tranId = transactionXElement.Element("tranId").Value;
            string tranName = transactionXElement.Element("tranName").Value;
            //transform all <tranResult> Xelements into Class objects
            //by passing the xml content of those tags into the TransResultFromXML selector function
            List<TranResult> transResults = transactionXElement.Element("tranResultList")?
                .Elements("tranResult")?.Select(TransResultFromXML).ToList();
            Transaction t = new Transaction()
            {
                TranId = tranId,
                TranName = tranName,
                TranResultList = transResults
            };
            return t;
        }
        public static TranResult TransResultFromXML(XElement transResultElement)
        {
            string state = transResultElement.Element("state").Value;
            string dateCreated = transResultElement.Element("created").Value;
            List<Document> docList;
            //transform all <doc> Xelements in <docList> into Class objects
            //by passing the xml content of those tags into the DocumentFromXML selector function
            docList = transResultElement.Element("docList")?
                .Elements("doc")?.Select(DocumentFromXML).ToList();
            List<Role> roleList;
            
            //transform all <role> Xelements in <roleList> into Class objects
            //by passing the xml content of those tags into the RoleFromXML selector function
            roleList = transResultElement.Element("roleList")?
                .Elements("role")?.Select(RoleFromXML).ToList();
            return new TranResult()
            {
                State = state,
                DateCreated = dateCreated,
                DocumentList = docList,
                RoleList = roleList
            };
        }
        public static Role RoleFromXML(XElement roleElement)
        {
            string id = roleElement.Attribute("id").Value;
            string roleName = roleElement.Attribute("role").Value;
            //A similar apttern has been used above - do same here
            List<Document> userDocList = roleElement.Element("docList")?
                .Elements("doc")?.Select(DocumentFromXML).ToList();
            User myUser = new User()
            {
                FirstName = roleElement.Element("firstName")?.Value,
                LastName = roleElement.Element("lastName")?.Value,
                Email = roleElement.Element("email")?.Value,
                DocumentList = userDocList
            };
            return new Role()
            {
                Id = id,
                RoleName = roleName,
                user = myUser
            };
        }
        public static Document DocumentFromXML(XElement docElement)
        {
            return new Document()
            {
                Id = docElement.Attribute("id").Value,
                Name = docElement.Attribute("name").Value,
                status = docElement.Attribute("status")?.Value
            };
        }
        static void Main(string[] args)
        {
            XDocument x = XDocument.Load(@"Path\To\transactions.xml");
            Transaction myTransaction = TransactionFromXML(GetTransaction(x));
            Console.WriteLine(myTransaction.TranResultList.ElementAt(1).RoleList.ElementAt(0).user.Email);
            Console.ReadLine();
        }
