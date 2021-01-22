            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var mailSettings = config.GetSectionGroup("system.net/mailSettings")
                    as MailSettingsSectionGroup;
                MailMessage msg = new MailMessage();
                msg.Subject = "Hi Raju";
                msg.To.Add("raju@hasten.in");
                msg.From = new MailAddress("hasten.c@hasten.in");
                msg.Body = "Hello Raju here everything is fine.";
                //MailSettingsSectionGroup msetting = null;
                string mMailHost = mailSettings.Smtp.Network.Host;
                SmtpClient mailClient = new SmtpClient(mMailHost);
                mailClient.Send(msg);
                MessageBox.Show("Mail Sent Succesfully...");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
