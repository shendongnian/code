    public void InventoryItemRowSelecting(PXCache sender, PXRowSelectingEventArgs e)
    {
        var row = e.Row as InventoryItem;
        if (row != null)
        {
            if (!string.IsNullOrEmpty(row.ImageUrl))
            {
                using (new PXConnectionScope())
                {
                    UploadFile uploadFile = PXSelectReadonly2<UploadFile, InnerJoin<NoteDoc, On<NoteDoc.fileID, Equal<UploadFile.fileID>>>,
                                                    Where<NoteDoc.noteID, Equal<Required<NoteDoc.noteID>>,
                                                    And<UploadFile.name, Like<Required<UploadFile.name>>>>>.
                                                    Select(Base, row.NoteID, "%icon%");
                    row.ImageUrl = (uploadFile != null) ? ControlHelper.GetAttachedFileUrl(null, uploadFile.FileID.ToString()) 
                                                            : null;
                }
            }
        }
    }
