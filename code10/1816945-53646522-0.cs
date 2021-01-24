            if (!Directory.Exists(mailbox))
            {
                Directory.CreateDirectory(mailbox);
            }
            MailServer oServer = new MailServer("servername",
                        "username", "password", ServerProtocol.Imap4);
            MailClient oClient = new MailClient("TryIt");
            oServer.SSLConnection = true;
            oServer.Port = 143;     
            try
            {
                oClient.Connect(oServer);
                MailInfo[] infos = oClient.GetMailInfos();
                for (int i = 0; i < infos.Length; i++)
                {
                    MailInfo info = infos[i];
                    Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}; Flags: {3}",
                        info.Index, info.Size, info.UIDL, info.Flags);
                    // Receive email from POP3 server
                    Mail oMail = oClient.GetMail(info);
                    Console.WriteLine("From: {0}", oMail.From.ToString());
                    Console.WriteLine("To: {0}", oMail.To.ToString());
                    Console.WriteLine("Subject: {0}\r\n", oMail.Subject);
                    if (oMail.Attachments.Length > 0)
                    {
                        for (int j = 0; j <= oMail.Attachments.Length - 1; j++)
                            {
                                System.DateTime d = System.DateTime.Now;
                                System.Globalization.CultureInfo cur = new System.Globalization.CultureInfo("en-US");
                                string sdate = d.ToString("MMddyyyyHHmmss", cur);
                                string fileName = String.Format("{0}\\{1}{2}{3}.eml", mailbox, sdate, d.Millisecond.ToString("d3"), i);
                                // Save email to local disk
                                oMail.SaveAs(fileName, true);
                                // Mark email as deleted from POP3 server.
                                oClient.Delete(info);
                            }
                        }
                }
                // Quit and purge emails marked as deleted from POP3 server.
                oClient.Quit();
            }
            catch (Exception ep)
            {
                Console.WriteLine(ep.Message);
            }
        
