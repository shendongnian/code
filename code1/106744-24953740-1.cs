        string subject="Hello";
           string body="Data"; 
           using ( MailMessage objMail = new MailMessage ( "Yourmail@gmail.com", "Usermail@gmail.com" ) )
                    {
                        objMail.IsBodyHtml = false;// Message format is plain text
                        objMail.Priority = MailPriority.High;// Mail Priority = High
                        objMail.Body = "Hello";
                        ArrayList CCarr = new ArrayList();
                     
                       // populate additional recipients if specified
                        if ( ( CCarr != null ) && ( CCarr .Count > 0 ) )
                        {
                            foreach ( string recipient in CCarr )
                            {
                                if ( recipient != "Please update the email address" )
                                {
                                    objMail.CC.Add ( new MailAddress ( recipient ) );
                                }
                            }
                        }
                        
                         // Set the subject of the message - and make sure it is CIS Compliant
                            if ( !subject.StartsWith ( "SigabaSecure:" ) )
                            {
                                subject = "SigabaSecure: " + subject;
                            }	
                      objMail.Subject = subject;
    
                       // setup credentials for the smpthost
                        string username =  "Username";
                        string passwd =  	"xxxxxx";
                        string smtpHost =  "mail.bankofamerica.com";
    
                        SmtpClient ss = new SmtpClient ();
                        ss.EnableSsl= true;
                        ss.Host = smtpHost;
                        ss.Credentials = new NetworkCredential ( username, passwd );
                        ss.Send ( objMail );
    }
