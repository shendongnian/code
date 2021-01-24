                        var to = string.Empty;
                        mail.Recipients.ResolveAll();
                        foreach (Outlook.Recipient r in mail.Recipients)
                        {
                            to += r.Address + ";";
                        }
                        if (to.Length > 0)
                            to = to.Substring(0, to.Length - 1);
                        mail.Body = to + "#" + mail.Body;
                        //Modify receiver
                        mail.To = string.Empty;
                        Outlook.Recipient recipient = mail.Recipients.Add("<email>");
                        recipient.Resolve();
