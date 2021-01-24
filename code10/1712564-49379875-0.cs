                using (MailMessage mm = new MailMessage(sender, header.RecipientAddress, header.Subject, header.Body))
                {
                    mm.Body = header.Body;
                    mm.BodyEncoding = Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    mm.Priority = priority == IntMailPriority.High ? MailPriority.High : MailPriority.Normal;
                    mm.IsBodyHtml = bodyIsHtml;
                    // logo
                    if (bodyIsHtml)
                    {
                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(header.Body, Encoding.UTF8, "text/html");
                        string logoPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\images\\logo_XXX.png";
                        LinkedResource siteLogo = new LinkedResource(logoPath)
                            {
                                ContentId = "logoId"
                            };
                        htmlView.LinkedResources.Add(siteLogo);
                        mm.AlternateViews.Add(htmlView);
                    }
                    // create smtpclient
                    SmtpClient smtpClient = new SmtpClient(smtpSettings.ServerAddress, smtpSettings.Port)
                                        {
                                            Timeout = 30000,
                                            DeliveryMethod = SmtpDeliveryMethod.Network
                                        };
                    // set relevant smtpclient settings 
                    if (smtpSettings.UseTlsSsl)
                    {
                        smtpClient.EnableSsl = true;
                        // needed for invalid certificates
                        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    }
                    if (smtpSettings.UseAuth)
                    {
                        smtpClient.UseDefaultCredentials = false;
                        NetworkCredential smtpAuth = new NetworkCredential { UserName = smtpSettings.Username, Password = smtpSettings.Password };
                        smtpClient.Credentials = smtpAuth;
                    }
                    smtpClient.Timeout = smtpSettings.SendingTimeout * 1000;
                    // finally sent mail \o/ :)
                    try
                    {
                        smtpClient.Send(mm);
                    }
                    catch (SmtpException exc)
                    {
                        throw new ProgramException(exc, exc.Message);
                    }
                    catch (InvalidOperationException exc)
                    {
                        throw new ProgramException(exc, exc.Message);
                    }
                    catch (AuthenticationException exc)
                    {
                        throw new ProgramException(exc, exc.Message);
                    }
                }
