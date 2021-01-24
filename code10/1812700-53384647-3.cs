    Company company = new TestBed.Company();
    
    company.Tables.Agri.Tables = new TablesArr[2];
    company.Tables.Agri.Tables[0] = new TablesArr();
    company.Tables.Agri.Tables[0].Tables = new Table[1];
    company.Tables.Agri.Tables[0].Tables[0] = new Table() { Id=1 };
    company.Tables.Agri.Tables[1] = new TablesArr();
    company.Tables.Agri.Tables[1].Tables = new Table[1];
    company.Tables.Agri.Tables[1].Tables[0] = new Table() { Id=2 };
    
    company.Tables.Tables = new TablesArr[2];
    company.Tables.Tables[0] = new TablesArr();
    company.Tables.Tables[0].Tables = new Table[1];
    company.Tables.Tables[0].Tables[0] = new TestBed.Table() { Id=3 };
    
    company.Tables.Tables[1] = new TablesArr();
    company.Tables.Tables[1].Tables = new Table[1];
    company.Tables.Tables[1].Tables[0] = new TestBed.Table() { Id=4 };
    
    
    XmlSerializer sx = new XmlSerializer(company.GetType());
    
    using (MemoryStream ms = new MemoryStream())
    {
    	sx.Serialize(ms, company);
    
    	ms.Seek(0, SeekOrigin.Begin);
    
    	Console.WriteLine("[{0}]", Encoding.UTF8.GetString(ms.ToArray()));
    }
