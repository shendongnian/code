    public void FormsAuthentication_OnAuthenticate(object sender, 
                               FormsAuthenticationEventArgs args)
        {
            if (FormsAuthentication.CookiesSupported)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(
                          Request.Cookies[FormsAuthentication.FormsCookieName].Value);
                        DateTime lastCheckedTime = DateTime.TryParse(ticket.UserData);
                        TimeSpan elapsed = DateTime.Now - lastCheckedTime;
                        if (elapsed.TotalMinutes > 10)//Get 10 from the config
                        {
                            //Check if user exists in the database. 
                            if (CheckIfUserIsValid())
                            {
                                //Reset the last checked time
                                // and set the authentication cookie again
                            }
                            else
                            {
                                FormsAuthentication.SignOut();
                                FormsAuthentication.RedirectToLoginPage();
                                return;
                            }
                        }
                        
                    }
                    catch (Exception e)
                    {
                        // Decrypt method failed.
                    }
                }
            }
        }
