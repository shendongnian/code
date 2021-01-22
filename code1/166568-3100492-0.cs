            XmlDocument doc = new XmlDocument();
            doc.Load("example.xml");
            if (doc.FirstChild is XmlProcessingInstruction)
            {
                XmlProcessingInstruction processInfo = (XmlProcessingInstruction) doc.FirstChild;
                Console.WriteLine(processInfo.Data);
                Console.WriteLine(processInfo.Name);
                Console.WriteLine(processInfo.Target);
                Console.WriteLine(processInfo.Value);
            }
