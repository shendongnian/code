    protected void SendMail(List<string> attachments)
        {
            UserManagement Users = new UserManagement();
            Users.GetUserInformation();
            SmtpClient client = new SmtpClient(ip_address);
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress(senderaddress);
            Message.To.Add(Users._CurUser_Destination_Email);
            Message.Subject = "Neue Umlagerung - " + cb_auflieger_limburg.SelectedItem.ToString();
            Message.Body = string.Format("Datum: {0}", DateTime.Now) + Environment.NewLine +
                                         "AufliegerNr.: " + cb_auflieger_limburg.SelectedItem.ToString() + Environment.NewLine +
                                         "Benutzer: " + Environment.UserName;
            client.UseDefaultCredentials = true;
            Attachment Attachment = null;
            try
            {
                foreach (string attachment in attachments)
                {
                    Attachment = new Attachment(attachment);
                    Message.Attachments.Add(Attachment);
                }
                client.Send(Message);
                Attachment.Dispose();
                Message.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                foreach(string attachment in attachments)
                {
                    //Dateien nach Versendung löschen
                    FileInfo fi = new FileInfo(attachment);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                }
            }
        }
