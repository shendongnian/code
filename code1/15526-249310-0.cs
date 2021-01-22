        public List<XDocument> ChunkDocket(XDocument docket, int chunkSize)
        {
            var d = new XDocument(docket);
            var newDockets = new List<XDocument>();
            while (d.Root.Elements("order").Any())
            {
                var newDocket = new XDocument(new XElement("docket"));
                do
                {
                    var currentOrder = d.Root.Element("order");
                    if (currentOrder == null) break;
                    
                    newDocket.Root.Add(currentOrder);
                    currentOrder.Remove();
                } while (newDocket.Root.Elements("order").Count() < chunkSize);
                newDockets.Add(newDocket);
            }
            return newDockets;
        }
