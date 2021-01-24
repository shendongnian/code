    public ActionResult PrintDocument(PrintViewModel model) 
    { 
        if (ModelState.IsValid) 
        { 
            using (var engine = new engine (true)) 
            { 
                LabelFormatDocument format = engine.Documents.Open(model SelectedDocument); 
                format.PageSetup.MediaHandling.Action = MediaHandlingActions.WaitForLabelTakenSensor; 
                format.PageSetUp.MediaHandling.Occurence = MediaHandlingOccurance.AfterEveryPage;
            }
        }
    }
