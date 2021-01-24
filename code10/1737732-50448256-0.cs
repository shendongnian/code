    tempFile = Path.GetTempFileName(); 
    using (View binaryView = session.Database.OpenView("SELECT Name, Data FROM Binary")) 
    { 
        binaryView.Execute(); 
        using (Record binaryRec = binaryView.Fetch()) 
        { 
            binaryRec.GetStream(2, tempFile); 
        } 
    }
