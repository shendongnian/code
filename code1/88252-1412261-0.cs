    public static string[] GetLotusNotesHelpTickets()
    {
        NotesSession session = new NotesSession();
        session.Initialize(Password);
        Set notesDBDirectory = session.GetDbDirectory("NTNOTES1A")
        // 85256B45:000EE057 = NTNOTES1A Server Replica ID
        NotesDatabase database = notesDBDirectory.OpenDatabaseByReplicaID("85256B45:000EE057")
        string SearchFormula = string.Concat("Form = \"Call Ticket\""
                                        , " & GroupAssignedTo = \"Business Systems\""
                                        , " & CallStatus = \"Open\"");
        NotesDocumentCollection collection = database.Search(SearchFormula, null, 0);
        NotesDocument document = collection.GetFirstDocument();
        string[] ticketList = new string[collection.Count];
    
        for (int i = 0; i < collection.Count; ++i)
        {
            ticketList[i] = ((object[])(document.GetItemValue("TicketNumber")))[0].ToString();
            document = collection.GetNextDocument(document);
        }
    
        document = null;
        collection = null;
        database = null;
        session = null;
        return ticketList;
    }
