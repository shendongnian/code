    System.Xml.XmlTextReader xr = new XmlTextReader(@"file.xml");
            while (xr.Read())
            {
                if (xr.LocalName == "name" && xr.Prefix == "a")
                {
                    xr.Read();
                    Console.WriteLine(xr.Value);
                }
            }
