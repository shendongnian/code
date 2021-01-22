    public void OutputAddress()
    {
       XDocument data = xmlData.GetXDocument();
       string Expected = "TestData";
       var result = from 
           addesses in data.Element("root").Elements("Addresses") 
       where 
           addesses.Element("item").Element("Address1").Value != string.Empty
       select addesses.Element("item").Element("Address1").Value;
    
       foreach (string address1 in result)
       {
           Console.Write(address1);
        }
    }
