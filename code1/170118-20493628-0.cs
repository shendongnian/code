                                olMail = outlook.CreateItem(0);  
                                olMail.To = toEmailID;
                                olMail.Subject = "Subject";
                               
                                if (attachments != null)
                                {
                                    foreach (var path in attachments)
                                    {
                                        olMail.Attachments.Add(path);
                                    }
                                }
                                
                                olMail.Display();
                                //Display email first and then write body text to get original email template and signature text.
                                if (string.IsNullOrWhiteSpace(htmlBody))
                                {
                                    if (!string.IsNullOrWhiteSpace(body))
                                    {
                                        olMail.Body = body + olMail.Body;
                                    }
                                }
                                else
                                {
                                    olMail.HTMLBody = htmlBody + olMail.HTMLBody;
                                }
