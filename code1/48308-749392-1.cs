    using (CaseNotesDataContext db = new CaseNotesDataContext()) {
        Table<CN_MaintItem> caseNotesItems = db.GetTable<CN_MaintItem>();
        chkContactType.DataSource = caseNotesItems.GetItemDescriptions(2);
        lkuContactLocation.Properties.DataSource = caseNotesItems.GetItemDescriptions(3);
        // etc... 
    }
