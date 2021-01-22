    XtraReport customReport;
    customReport = new MyXtraReport();
    byte[] layout = LoadCustomLayoutFromDB();
    if (layout != null) {
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(layout)) {
            customReport.LoadLayout(memoryStream);
        }
    }
    using (XRDesignFormEx designer = new XRDesignFormEx()) {
        MySaveCommandHandler customCommands = new MySaveCommandHandler(designer.DesignPanel);
        designer.DesignPanel.AddCommandHandler(customCommands);
        designer.OpenReport(customReport);
        designer.ShowDialog(this);
        if (customCommands.ChangesSaved)
            SaveCustomLayoutToDB(customCommands.Layout);
    }
