    public void InventoryItemRowSelecting(PXCache sender, PXRowSelectingEventArgs e)
    {
        var row = e.Row as InventoryItem;
        if (row == null)
            return;  // Don't proceed when row doesn't exist
            
        if (string.IsNullOrEmpty(row.ImageUrl))
            return; // Don't proceed when ImageUrl doesn't exist
            
        foreach (NoteDoc noteDoc in PXSelectReadonly<NoteDoc, Where<NoteDoc.noteID, Equal<Required<NoteDoc.noteID>>>>.Select(Base, row.NoteID)) // here i got error
        {
            foreach (UploadFile uploadFile in PXSelectReadonly<UploadFile, Where<UploadFile.fileID, Equal<Required<UploadFile.fileID>>>>.Select(Base, noteDoc.FileID))
            {
                if (!uploadFile.Name.Contains("icon"))
                    continue;  // Skip non-icon files
                
                row.ImageUrl = ControlHelper.GetAttachedFileUrl(null, uploadFile.FileID.ToString());
            }
        }
    }
