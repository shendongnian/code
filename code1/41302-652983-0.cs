    public Outlook.MAPIFolder getInbox()
    		{
    			mailSession = new Outlook.Application();
    			mailNamespace = mailSession.GetNamespace("MAPI");
    			mailNamespace.Logon(mail_username, mail_password, false, true);
    			return MailNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
    		}
