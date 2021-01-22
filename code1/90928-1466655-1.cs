    Domino.NotesSessionClass _lotesNotesSession = new Domino.NotesSessionClass();
    //Initializing Lotus Notes Session
    _lotesNotesSession.Initialize( "my_password" );
    Domino.NotesDatabase _serverDatabase = _lotesNotesSession.GetDatabase( "some_server", "names.nsf", false );
    if (_serverDatabase == null){
       System.Console.Writeline("Can not connect to server.");
    }
