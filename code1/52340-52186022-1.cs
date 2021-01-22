            public void ReadToXML()
            {    
                try
                {
                    var xEle = new XElement("Items",
                                from item in items
                                select new XElement("Item",
                                               new XElement("mhid", item.mhid),
                                               new XElement("hotelName", item.hotelName),
                                               new XElement("destination", item.destination),
                                               new XElement("destinationID", item.destinationID),
                                               new XElement("rank", item.rank),
                                               new XElement("toDisplayOnFod", item.toDisplayOnFod),
                                               new XElement("comment", item.comment),
                                               new XElement("Destinationcode", item.Destinationcode),
                                               new XElement("LoadDate", item.LoadDate)
                                           ));
    
                    xEle.Save("E:\\employees.xml");
                    Console.WriteLine("Converted to XML");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
