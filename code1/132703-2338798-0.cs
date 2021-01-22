    public PreApplication() {}
    
    public DoInsert {
      PreApplicationsDataContext db =
        new PreApplicationsDataContext("Data Source=THESQLSERVER;Initial Catalog=THECONNECTIONSTRING;Integrated Security=True");
      tblPreApplication preApp = new tblPreApplication();
      preApp.FileName = FileName;
      preApp.FileType = FileType;
      preApp.FileSize = FileSize;
      preApp.FileContent = (byte[])FileContent;
      try {
        db.tblPreApplications.InsertOnSubmit(preApp);
        db.SubmitChanges();
        DatabaseId = preApp.Applicant_PK;
        return preApp.Applicant_PK;
      } catch {
        DatabaseId = 0;
        return 0;   
      }  
    }
