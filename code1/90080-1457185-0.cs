    public void GetAttachments()
        {
        NotesSession session = new NotesSession();
        //NotesDocument notesDoc = new NotesDocument();
        session.Initialize("");
        NotesDatabase NotesDb = session.GetDatabase("", "C:\\temps\\lotus\\sss11.nsf", false); //Open Notes Database
        NotesView inbox = NotesDb.GetView("By _Author");
        NotesDocument docInbox = inbox.GetFirstDocument();
        
        // Check if any attachments
        if (docInbox.hasEmbedded)
        {
            NotesEmbeddedObject attachfile = (NotesEmbeddedObject)docInbox.embeddedObjects[0];
            if (attachfile != null)
            {
                attachfile.ExtractFile("C:\\temps\\export\\" + attachfile.name);
            }
        }
