    public class GmailExtract : IMailContactExtract
        {
            private const string ContinueUrl = "http://mail.google.com/mail?ui=html&amp;zy=l";
            private const string ExportUrl = "https://mail.google.com/mail/contacts/data/export?exportType=ALL&groupToExport=&out=GMAIL_CSV";
            private const string LoginRefererUrl = "https://www.google.com/accounts/ServiceLogin?service=mail&passive=true&rm=false&continue=http%3A%2F%2Fmail.google.com%2Fmail%2F%3Fui%3Dhtml%26zy%3Dl&ltmpl=default&ltmplcache=2";
            private const string LoginUrl = "https://www.google.com/accounts/ServiceLoginAuth?service=mail";
            private const string UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 1.1.4322; .NET CLR 2.0.50727; InfoPath.1; .NET CLR 1.0.3705; .NET CLR 3.0.04506.30)";
    
            #region IMailContactExtract Members
    
            public bool Extract( NetworkCredential credential, out MailContactList list)
            {
                bool result = false;
                list = new MailContactList();
    
                try
                {
                    CookieCollection cookies = new CookieCollection();
    
                    // Prepare login form data
                    HttpValueCollection loginFormValues = new HttpValueCollection();
                    loginFormValues[ "ltmpl" ] = "default";
                    loginFormValues[ "ltmplcache" ] = "2";
                    loginFormValues[ "continue" ] = ContinueUrl;
                    loginFormValues[ "service" ] = "mail";
                    loginFormValues[ "rm" ] = "false";
                    loginFormValues[ "hl" ] = "en";
                    loginFormValues[ "Email" ] = credential.UserName;
                    loginFormValues[ "Passwd" ] = credential.Password;
                    loginFormValues[ "PersistentCookie" ] = "true";
                    loginFormValues[ "rmShown" ] = "1";
                    loginFormValues[ "null" ] = "Sign In";
    
                    // Convert to bytes
                    byte[] loginPostData = Encoding.UTF8.GetBytes( loginFormValues.ToString( true ) );
    
                    HttpWebRequest loginRequest = ( HttpWebRequest ) WebRequest.Create( LoginUrl );
                    loginRequest.Method = "POST";
                    loginRequest.UserAgent = UserAgent;
                    loginRequest.Referer = LoginRefererUrl;
                    loginRequest.ContentType = "application/x-www-form-urlencoded";
                    loginRequest.ContentLength = loginPostData.Length;
                    loginRequest.AllowAutoRedirect = false;
    
                    // Create cookie container
                    loginRequest.CookieContainer = new CookieContainer();
    
                    // Add post data to request
                    Stream stream;
                    using ( stream = loginRequest.GetRequestStream())
                    {
                        stream.Write( loginPostData, 0, loginPostData.Length);
                    }
    
                    HttpWebResponse loginResponse = ( HttpWebResponse ) loginRequest.GetResponse();
    
                    cookies.Add( loginResponse.Cookies );
    
                    // Create request to export Google CSV page
                    HttpWebRequest contactsRequest = ( HttpWebRequest ) WebRequest.Create( ExportUrl );
                    contactsRequest.Method = "GET";
                    contactsRequest.UserAgent = UserAgent;
                    contactsRequest.Referer = loginResponse.ResponseUri.ToString();
    
                    // use cookie gotten from login page
                    contactsRequest.CookieContainer = new CookieContainer();
                    foreach ( Cookie cookie in cookies )
                    {
                        contactsRequest.CookieContainer.Add( cookie );
                    }
    
                    HttpWebResponse exportResponse = ( HttpWebResponse ) contactsRequest.GetResponse();
    
                    // Read data from response stream
                    string csvData;
                    using ( Stream responseStream = exportResponse.GetResponseStream())
                    {
                        using ( StreamReader streamRead = new StreamReader( responseStream ) )
                        {
                            csvData = streamRead.ReadToEnd();
                        }
                    }
    
                    // parse google csv
                    string[] lines = csvData.Split( '\n' );
                    foreach ( string line in lines )
                    {
                        string[] values = line.Split( ',' );
                        if ( values.Length < 2 )
                        {
                            continue;
                        }
    
                        MailContact mailContact = new MailContact();
                        mailContact.Email = values[ 1 ];
                        mailContact.Name = values[ 0 ];
                        if (mailContact.Email.Trim().Length > 0)
                        {
                            if (Common.IsValidEmail(mailContact.Email))
                            {
                                list.Add(mailContact);
                            }
                        }
                    }
    
                    result = true;
                }
                catch
                {
                }
    
                return result;
            }
    
            #endregion
        }
