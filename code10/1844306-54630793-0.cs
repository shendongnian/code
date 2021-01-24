            public void ComposeMemo(String sendto, String subject, String body)
        {
            //BLOC1 instantiate a Notes session and workspace
            Type NotesSession = Type.GetTypeFromProgID("Notes.NotesSession");
             Type NotesUIWorkspace = Type.GetTypeFromProgID("Notes.NotesUIWorkspace");
             Object sess = Activator.CreateInstance(NotesSession);
             Object ws = Activator.CreateInstance(NotesUIWorkspace);
            //BLOC2 open current user's mail file
            String mailServer = (String)NotesSession.InvokeMember("GetEnvironmentString", BindingFlags.InvokeMethod, null, sess, new Object[] { "MailServer", true });
            String mailFile = (String)NotesSession.InvokeMember("GetEnvironmentString", BindingFlags.InvokeMethod, null, sess, new Object[] { "MailFile", true });
            NotesUIWorkspace.InvokeMember("OpenDatabase", BindingFlags.InvokeMethod, null, ws, new Object[] { mailServer, mailFile });
            Object uidb = NotesUIWorkspace.InvokeMember("GetCurrentDatabase", BindingFlags.InvokeMethod, null, ws, null);
            Object db = NotesUIWorkspace.InvokeMember("Database", BindingFlags.GetProperty, null, uidb, null);
            Type NotesDatabase = db.GetType();
            //BLOC3 compose a new memo
            Object uidoc = NotesUIWorkspace.InvokeMember("ComposeDocument", BindingFlags.InvokeMethod, null, ws, new Object[] { mailServer, mailFile, "Memo", 0, 0, true });
            Type NotesUIDocument = uidoc.GetType();
            NotesUIDocument.InvokeMember("FieldSetText", BindingFlags.InvokeMethod, null, uidoc, new Object[] { "EnterSendTo", sendto });
            NotesUIDocument.InvokeMember("FieldSetText", BindingFlags.InvokeMethod, null, uidoc, new Object[] { "Subject", subject });
            NotesUIDocument.InvokeMember("FieldSetText", BindingFlags.InvokeMethod, null, uidoc, new Object[] { "Body", body });
            //BLOC4 bring the Notes window to the front
            String windowTitle = (String)NotesUIDocument.InvokeMember("WindowTitle", BindingFlags.GetProperty, null, uidoc, null);
            Interaction.AppActivate(windowTitle);
        }
