        private RDOSession _MailSession = new RDOSession();
        private RDOFolder _IncommingInbox;
        private RDOFolder _ArchiveFolder;
        private string _SaveAttachmentPath;
    
        public MailBox(string Logon_Profile, string IncommingMailPath, 
                       string ArchiveMailPath, string SaveAttPath)
        {
            _MailSession.Logon(Logon_Profile, null, null, true, null, null);
            _IncommingInbox = _MailSession.GetFolderFromPath(IncommingMailPath);
            _ArchiveFolder = _MailSession.GetFolderFromPath(ArchiveMailPath);
            _SaveAttachmentPath = SaveAttPath;
        }
    public void ProcessMail()
            {
                
                foreach (RDOMail msg in _IncommingInbox.Items)
                {
                    foreach (RDOAttachment attachment in msg.Attachments)
                    {
                        attachment.SaveAsFile(_SaveAttachmentPath + attachment.FileName);
                        }
                    }
                    if (msg.Body != null)
                    {
                        ProcessBody(msg.Body);
                    }
                }
    
            }
