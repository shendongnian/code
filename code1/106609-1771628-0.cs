    foreach (Document doc in ImportDocs) {
        // make copy of doc that lives inside loop scope
        Document copydoc = new Document() {
            field1 = doc.field1,
            field2 = doc.field2,
            // complete copy
        };
        using (var dc = new DocumentClassesDataContext(connection)) {
            byte[] contents = File.ReadAllBytes(copydoc.FileName);
    
            DocumentSubmission submission = new DocumentSubmission() {
                Content = contents,
                // other fields
            };
    
            dc.DocumentSubmissions.InsertOnSubmit(submission);  // (A)
            dc.SubmitChanges();                                 // (B)
        }
    }
