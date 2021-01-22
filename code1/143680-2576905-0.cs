    Project3DataSet.ReadXmlSchema(  
        new StringReader(Project2WebService.GetCustomersDataSetSchema()));
    
    [WebMethod]
    public string GetCustomersDataSetSchema()
    {
       return new Project1DataSet().GetXmlSchema();
    }
