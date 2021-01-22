        static void Main(string[] args)
        {            
            XDocument yourDoc = XDocument.Load("the.xml");
            var q = from c in yourDoc.Descendants("resource")
                    orderby (int) c.Attribute("key")
                    select c.Attribute("key").Value + ":" + c.Value;
            foreach (string s in q)
                Console.WriteLine(s);                            
            Console.ReadLine();
        }
