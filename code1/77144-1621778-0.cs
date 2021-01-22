    NotesSession s = new Domino.NotesSessionClass();
    s.Initialize("MyPassword");
    NotesDbDirectory d = s.GetDbDirectory ("MyServer");
    NotesDatabase db = d.GetFirstDatabase();
    ...
    
    // loop over all DB's
    String sPath = db.filePath;
    String sTemplateName = db.TemplateName;
    // here, you can check if the template name contains "mail", for example
    ...
    db = d.getNextDatabase (db);
    ...
  
