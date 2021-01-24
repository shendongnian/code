    XNamespace ns = XNamespace.Get("http://XMLPolling/JDEOrderQueue");
    XDocument doc = XDocument.Load("xml.xml");
    XElement orderID = doc.Elements(ns + "OrderID").FirstOrDefault();
    if(orderID != null)
    {
        XElement phWork = orderID.Elements("PHWork.dbo.JDE_Order_Queue").FirstOrDefault();
        if(phWork != null)
        {
            string oderno = phWork.Attribute("orderno")?.Value;
        }
    }
