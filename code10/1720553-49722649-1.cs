    class ReadFileFromFolder
        {
            public static void Main()
            {
                XDocument xdoc = XDocument.Load("catalog.xml");
                foreach (XElement element in xdoc.Descendants())
                {
                    if(element.Name == "product"){
                        Console.WriteLine(element.Attributes("product-id").Value);;   
                    }
                }
            }
        }
