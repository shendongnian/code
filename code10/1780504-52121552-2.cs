    public void InventoryItemRowSelecting(PXCache sender, PXRowSelectingEventArgs e)
    {
        var row = e.Row as InventoryItem;
        if (row == null)
            return;  // Don't proceed when row doesn't exist
        
        if (string.IsNullOrEmpty(row.ImageUrl))
            return; // Don't proceed when ImageUrl doesn't exist
        using (new PXConnectionScope())
        {
            UploadFile uploadFile = PXSelectReadonly2<UploadFile, InnerJoin<NoteDoc, On<NoteDoc.fileID, Equal<UploadFile.fileID>>>,
                                        Where<NoteDoc.noteID, Equal<Required<NoteDoc.noteID>>,
                                        And<UploadFile.name, Like<Required<UploadFile.name>>>>>.
                                        Select(Base, row.NoteID, "%icon%");
            if (uploadFile == null)
                continue; // Skip non-icon files         
            row.ImageUrl = ControlHelper.GetAttachedFileUrl(null, uploadFile.FileID.ToString()); 
        }
    }
