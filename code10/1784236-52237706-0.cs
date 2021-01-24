    public async Task<DocumentLine> CreateNewAsync(Document parent)
    {
        try
        {
            DocumentLine documentLine = new DocumentLine();
            documentLine.ParentDocument = parent;
            var newDocumentLine = await databaseContext.DocumentLines.AddAsync(documentLine);
            await databaseContext.SaveChangesAsync();
            return newDocumentLine.Entity;
        }
        catch(Exception ex)
        {
            return null;
        }
    }
