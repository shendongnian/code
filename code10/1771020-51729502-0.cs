    XDocument doc = XDocument.Parse(responseStr);
    XNamespace ns = doc.Root.GetDefaultNamespace();
    string upc = "";
    string ean = "";
    if (doc.Descendants(ns + "Ack").FirstOrDefault().Value != "Failure")
    {
        string candidateUpc = (string) doc.Descendants(ns + "UPC").FirstOrDefault();        
        if (candidateUpc != null && Regex.IsMatch(candidateUpc, @"^\d+$"))
        {
            upc = candidateUpc;
        }
        string candidateEan = (string) doc.Descendants(ns + "EAN").FirstOrDefault();        
        if (candidateEan != null && Regex.IsMatch(candidateEan, @"^\d+$"))
        {
            ean = candidateEan;
        }
    }
